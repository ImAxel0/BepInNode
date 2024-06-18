using BepInNode.Graph;
using BepInNode.Style;
using BepInNode.Utilities;
using IconFonts;
using ImGuiNET;
using System.Numerics;
using static BepInNode.Core.NodeList.Filtering;

namespace BepInNode.Core
{
    public class NodeList
    {
        private static string _searchBuffer = string.Empty;
        public static bool HideArguments;

        public static Dictionary<Node.NodeCategories, Dictionary<string, Node>> OrderedCategoryNodesPair = new();
        public static Dictionary<Node.NodeCategories, Dictionary<string, Node>> CategoryNodesPair = new()
        {
            { Node.NodeCategories.Misc, new Dictionary<string, Node>() },
            { Node.NodeCategories.GameObject, new Dictionary<string, Node>() },
            { Node.NodeCategories.Transform, new Dictionary<string, Node>() },
            { Node.NodeCategories.MonoBehaviour, new Dictionary<string, Node>() },
            { Node.NodeCategories.Input, new Dictionary<string, Node>() },
            { Node.NodeCategories.Math, new Dictionary<string, Node>() },
            { Node.NodeCategories.Vector2, new Dictionary<string, Node>() },
            { Node.NodeCategories.Vector3, new Dictionary<string, Node>() },
            { Node.NodeCategories.TypeUtility, new Dictionary<string, Node>() },
            { Node.NodeCategories.Fields, new Dictionary<string, Node>() },
            { Node.NodeCategories.Properties, new Dictionary<string, Node>() },
            { Node.NodeCategories.BepInEx, new Dictionary<string, Node>() },
            { Node.NodeCategories.Rigidbody, new Dictionary<string, Node>() },
            { Node.NodeCategories.Physics, new Dictionary<string, Node>() },
            { Node.NodeCategories.SceneManager, new Dictionary<string, Node>() },
            { Node.NodeCategories.Flow, new Dictionary<string, Node>() },
            { Node.NodeCategories.Events, new Dictionary<string, Node>() },
            { Node.NodeCategories.Methods, new Dictionary<string, Node>() },
            { Node.NodeCategories.Camera, new Dictionary<string, Node>() },
        };

        public static Tabs _selectedTab = Tabs.Variables;
        public enum Tabs
        {
            Variables,
            Log
        }

        public static class Filtering
        {
            public static Type InputFilter = typeof(All);
            public static Type OutputFilter = typeof(All);

            public enum All { }

            public static List<Type> FilterTypes = new()
            {
                typeof(All),
                typeof(int), typeof(bool), typeof(float),
                typeof(string), typeof(Vector3), typeof(Vector2),
            };
        }

        private static void OrderCategoriesAlphabetically()
        {
            var sortedKeys = CategoryNodesPair.Keys.OrderBy(key => key.ToString());
            foreach (var key in sortedKeys)
            {
                OrderedCategoryNodesPair.Add(key, CategoryNodesPair[key]);
            }
        }

        private static bool FilterNode(Node node)
        {
            if (!node.Name.ToLower().Contains(_searchBuffer.ToLower()))
                return false;

            if (InputFilter != typeof(All))
            {
                if (!node.ArgsIn.Any(x => x.Type == InputFilter))
                    return false;
            }

            if (OutputFilter != typeof(All))
            {
                if (!node.ArgsOut.Any(x => x.Type == OutputFilter))
                    return false;
            }
            return true;
        }

        public static void Render()
        {
            ImGui.BeginChild("NodeListWindow", new(470, ImGui.GetContentRegionAvail().Y), ImGuiChildFlags.Border | ImGuiChildFlags.ResizeX);

            ImGui.BeginChild("MainNodeListTopBar", new(ImGui.GetContentRegionAvail().X, 115));
            ImGui.PushFont(FontController.GetFontOfSize(20));
            ImGui.InputTextWithHint($"Search node {FontAwesome6.MagnifyingGlass}", "...", ref _searchBuffer, 1000);
            ImGui.PopFont();

            if (ImGui.BeginCombo("Input filter", InputFilter.Name, ImGuiComboFlags.HeightLargest))
            {
                foreach (var type in FilterTypes)
                {
                    if (ImGui.Selectable(type.Name))
                        InputFilter = type;
                }
                ImGui.EndCombo();
            }

            if (ImGui.BeginCombo("Output filter", OutputFilter.Name, ImGuiComboFlags.HeightLargest))
            {
                foreach (var type in FilterTypes)
                {
                    if (ImGui.Selectable(type.Name))
                        OutputFilter = type;
                }
                ImGui.EndCombo();
            }

            ImGui.PushFont(FontController.GetFontOfSize(20));
            ImGui.SeparatorText("Node list");
            ImGui.PopFont();

            ImGui.EndChild();

            if (OrderedCategoryNodesPair.Count == 0)
                OrderCategoriesAlphabetically(); // only called once to alphabetically order all nodes

            ImGui.BeginChild("MainNodeList", new(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y / 1.5f), ImGuiChildFlags.ResizeY);

            foreach (var nodeCategory in OrderedCategoryNodesPair)
            {
                if (ImGui.CollapsingHeader(nodeCategory.Key.ToString()))
                {
                    int nColumn = HideArguments ? 1 : 3;
                    ImGui.BeginTable(nodeCategory.Key.ToString(), nColumn, ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.BordersOuterH | ImGuiTableFlags.PadOuterX);
                    ImGui.TableSetupColumn("Name");
                    ImGui.TableSetupColumn("Inputs");
                    ImGui.TableSetupColumn("Outputs");
                    ImGui.TableHeadersRow();

                    foreach (var node in nodeCategory.Value.Values)
                    {
                        if (!FilterNode(node))
                            continue;

                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        if (ImGui.Selectable(node.Name, false, ImGuiSelectableFlags.AllowDoubleClick))
                        {
                            if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                            {
                                NodesHandling.AddToGraph(node, new(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y));
                            }
                        }
                        Helpers.NodeListTooltip(node.Name, node.Description);

                        if (HideArguments)
                            continue;

                        ImGui.TableSetColumnIndex(1);

                        int offset = 0;
                        node.ArgsIn.ForEach(argIn =>
                        {
                            Drawings.DrawNodeListArgInCircle(argIn);
                            ImGui.SameLine(offset += 15);
                        });

                        ImGui.TableSetColumnIndex(2);

                        int offset2 = 0;
                        node.ArgsOut.ForEach(argOut =>
                        {
                            Drawings.DrawNodeListArgOutCircle(argOut);
                            ImGui.SameLine(offset2 += 15);
                        });
                    }
                    ImGui.EndTable();
                }
            }
            ImGui.EndChild();

            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.18f, 0.18f, 0.19f, 1);
            ImGui.BeginChild("MainNodeListBottom", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

            if (ImGui.BeginCombo("##_selectedTab", _selectedTab.ToString()))
            {
                foreach (var opt in Enum.GetValues<Tabs>())
                {
                    if (ImGui.Selectable(opt.ToString()))
                        _selectedTab = opt;
                }
                ImGui.EndCombo();
            }

            switch (_selectedTab)
            {
                case Tabs.Variables:
                    VariablesManager.Render();
                    break;
                case Tabs.Log:
                    Logger.Render();
                    break;
            }
            ImGui.EndChild();

            ImGui.EndChild();
        }
    }

}
