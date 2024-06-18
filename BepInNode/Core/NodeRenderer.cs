using BepInNode.CustomAttributes;
using BepInNode.Graph;
using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using System.Numerics;
using System.Reflection;

namespace BepInNode.Core
{
    public class NodeRenderer
    {
        private static Vector2 GetWhatSizeNodeShouldBe(Node node)
        {
            if (node.SizeOverride != Vector2.Zero)
                return node.SizeOverride;

            switch (node.ArgsIn.Count)
            {
                case 0:
                    return new Vector2(230, 100);
                case 1:
                    return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 120) : new Vector2(250, 180);
                case 2:
                    return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 150) : new Vector2(250, 220);
                case 3:
                    return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 180) : new Vector2(250, 270);
                case 4:
                    return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 210) : new Vector2(250, 320);
                case 5:
                    return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 240) : new Vector2(250, 380);
                case 6:
                    return node.ArgsIn.All(x => x.HasConnection && node.ArgsOut.Count <= 1) ? new Vector2(230, 270) : new Vector2(250, 430);
            }
            return new Vector2(250, 180);
        }

        private static void DrawStaticInput(Node node, PropertyInfo property)
        {
            ImGui.BeginChild($"Inputs_{node.Name}", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border, ImGuiWindowFlags.NoScrollbar
                | ImGuiWindowFlags.NoScrollWithMouse);

            ImGui.SetWindowFontScale(GraphEditor.Zoom);

            if (property.PropertyType == typeof(int))
            {
                int value = (int)property.GetValue(node);
                ImGui.DragInt(property.Name, ref value);
                property.SetValue(node, value);
            }
            else if (property.PropertyType == typeof(float))
            {
                float value = (float)property.GetValue(node);
                ImGui.DragFloat(property.Name, ref value, 0.1f, float.NegativeInfinity, float.PositiveInfinity, "%.1f");
                property.SetValue(node, value);
            }
            else if (property.PropertyType == typeof(bool))
            {
                bool value = (bool)property.GetValue(node);
                ImGui.Checkbox(property.Name, ref value);
                property.SetValue(node, value);
            }
            else if (property.PropertyType == typeof(string))
            {
                ImGuiInputTextFlags flags = CharsNoBlankTypes.CharsNoBlank.Any(x => x == node.GetType())
                    ? ImGuiInputTextFlags.CharsNoBlank : ImGuiInputTextFlags.None;

                string value = (string)property.GetValue(node);
                if (string.IsNullOrEmpty(value))
                    value = "";

                ImGui.InputTextWithHint($"##{property.Name}", property.Name, ref value, 10000, flags);
                property.SetValue(node, value);
            }
            else if (property.PropertyType == typeof(Vector2))
            {
                Vector2 value = (Vector2)property.GetValue(node);
                ImGui.DragFloat2(property.Name, ref value, 1, float.NegativeInfinity, float.PositiveInfinity, "%.1f");
                property.SetValue(node, value);
            }
            else if (property.PropertyType == typeof(Vector3))
            {
                Vector3 value = (Vector3)property.GetValue(node);
                ImGui.DragFloat3(property.Name, ref value, 1, float.NegativeInfinity, float.PositiveInfinity, "%.1f");
                property.SetValue(node, value);
            }
            else if (property.PropertyType == typeof(List<Enum>))
            {
                List<Enum> value = (List<Enum>)property.GetValue(node);
                var enumProp = node.GetType().GetProperty("EnumValue");
                if (ImGui.BeginCombo(enumProp.PropertyType.Name, enumProp.GetValue(node).ToString(), ImGuiComboFlags.HeightLarge))
                {
                    foreach (var option in value)
                    {
                        if (ImGui.Selectable(option.ToString()))
                            enumProp.SetValue(node, option);
                    }
                    ImGui.EndCombo();
                }
            }

            ImGui.EndChild();
        }
        static int arguments;
        public static void RenderNode(Node node, int index)
        {
            ImGuiTheme.NodeTheme(node);

            var nodeProperties = node.GetType().GetProperties().Where(p => p.DeclaringType == node.GetType()
                && !p.GetCustomAttributes(typeof(IgnoreProperty), false).Any());

            NodesHandling.HandleCustomEvents(node, nodeProperties);

            ImGui.SetCursorPos(node.Position * GraphEditor.Zoom);
            GraphEditor.WindowPos = ImGui.GetWindowPos();

            ImGui.BeginChild($"Node_{index}_{node.Name}", GetWhatSizeNodeShouldBe(node) * GraphEditor.Zoom,
                ImGuiChildFlags.Border, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);

            ImGui.SetWindowFontScale(GraphEditor.Zoom);

            node.IsDragging = ImGui.IsWindowHovered() && ImGui.IsMouseDown(ImGuiMouseButton.Left);
            if (node.IsDragging || node == GraphEditor.SelectedNode && ImGui.IsMouseDown(ImGuiMouseButton.Left) && GraphEditor.IsEditorHovered)
            {
                if (!GraphEditor.DraggingOutput && !GraphEditor.IsPanning)
                {
                    node.Position += ImGui.GetIO().MouseDelta / GraphEditor.Zoom;
                    GraphEditor.SelectedNode = node;
                    GraphEditor.SelectedNodeSize = ImGui.GetWindowSize() / GraphEditor.Zoom;
                }
            }

            if (ImGui.IsMouseClicked(ImGuiMouseButton.Left) && !node.IsDragging)
                GraphEditor.SelectedNode = null;

            ImGui.PushFont(FontController.GetFontOfSize(18));
            ImGui.Text(node.Name);
            ImGui.PopFont();
            Helpers.NodeTooltip(node.Description);
            ImGui.Separator();

            ImGui.Columns(2, $"Columns_{index}_{node.Name}", false);
            ImGui.SetColumnWidth(0, GetWhatSizeNodeShouldBe(node).X * GraphEditor.Zoom / 1.2f);

            // Left column
            if (node.NodeType != Node.NodeTypes.Starter)
            {
                node.Input.Render(node);
                ImGui.Dummy(new(0, 20 * GraphEditor.Zoom));
                if (nodeProperties.Count() > 0 || node.ArgsIn.Count() > 0)
                {
                    ImGui.TextColored(new Vector4(1, 1, 1, 0.7f), "Inputs:");

                    node.ArgsIn.ForEach(arg =>
                    {

                        if (!arg.Hide)
                        {
                            arg.Render(node);
                            ImGui.Dummy(new(0, 5 * GraphEditor.Zoom));
                        }
                    });
                }
            }

            ImGui.NextColumn();

            int outputNum = 1;
            // Right column
            node.Outputs.ForEach(output =>
            {
                if (node.Outputs.Count > 1)
                {
                    ImGui.TextDisabled(outputNum.ToString());
                    outputNum++;
                }

                output.Render(node);
                if (node.Outputs.Count > 1 && node.Outputs.Last() != output)
                    ImGui.Dummy(new(0, 25 * GraphEditor.Zoom));
            });

            ImGui.Dummy(new(0, 25 * GraphEditor.Zoom));

            node.ArgsOut.ForEach(arg =>
            {
                arg.Render(node);
                if (node.ArgsOut.Count > 1)
                    ImGui.Dummy(new(0, 25 * GraphEditor.Zoom));
            });

            // End column
            ImGui.Columns(1);

            int idx = 0;
            foreach (var prop in nodeProperties)
            {
                if (node.ArgsIn[idx].HasConnection)
                {
                    idx++;
                    continue;
                }
                DrawStaticInput(node, prop);
                idx++;
            }

            ImGui.EndChild();

            node.Outputs.ForEach(output =>
            {
                if (output.HasConnection)
                    Drawings.DrawNodeLine(output.Position, output.NextNode.Input.Position);
            });

            node.ArgsOut.ForEach(arg =>
            {

                if (arg.HasConnection)
                    Drawings.DrawNodeArgumentLine(arg.Position, arg.InputArg.Position, ImGuiTheme.Colors.GetTypeColor(arg.Type));
            });

            if (GraphEditor.SelectedNode != null)
            {
                NodesHandling.UpdateSelectedNode(out var pos, out var size);

                ImGui.GetWindowDrawList().AddRect(pos + GraphEditor.WindowPos - GraphEditor.EditorScrollPos,
                    new Vector2(pos.X + size.X, pos.Y + size.Y) + GraphEditor.WindowPos - GraphEditor.EditorScrollPos,
                    ImGui.GetColorU32(ImGuiTheme.Colors.SelectedNodeColor), 5);
            }

            ImGuiTheme.ApplyTheme();
            NodesHandling.GetDragInput(node);
        }
    }
}
