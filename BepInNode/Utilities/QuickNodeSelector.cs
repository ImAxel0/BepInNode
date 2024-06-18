using BepInNode.Core;
using BepInNode.Graph;
using ImGuiNET;
using System.Numerics;

namespace BepInNode.Utilities
{
    public class QuickNodeSelector
    {
        public static Vector2? FixedPos;
        public static bool ShowSelector;
        public static string SearchBuffer = string.Empty;
        static bool _canToggle = true;
        static bool _focus = true;

        public static void ToggleSelector()
        {
            if (!_canToggle)
                return;

            FixedPos = null;
            SearchBuffer = string.Empty;
            _focus = true;
            ShowSelector = !ShowSelector;
            WaitForInput();
        }

        static async void WaitForInput()
        {
            _canToggle = false;
            await Task.Delay(100);
            _canToggle = true;
        }

        public static void Render()
        {
            FixedPos ??= ImGui.GetIO().MousePos;

            ImGui.SetNextWindowPos(FixedPos.Value, ImGuiCond.Always);
            ImGui.BeginChild("QuickNodeSelector", new(300, 600), ImGuiChildFlags.Border);

            ImGui.BeginChild("QuickNodeSelectorTopBar", new(ImGui.GetContentRegionAvail().X, 25));
            ImGui.InputText($"Search", ref SearchBuffer, 1000);
            if (_focus)
            {
                ImGui.SetKeyboardFocusHere(-1);
                _focus = false;
            }

            ImGui.SameLine();
            if (ImGui.Button("X"))
                ToggleSelector();

            ImGui.EndChild();

            ImGui.Separator();

            ImGui.BeginChild("QuickNodeSelectorList", ImGui.GetContentRegionAvail());

            SortedList<string, Node> sorted = new();

            foreach (var nodeCategory in NodeList.OrderedCategoryNodesPair)
            {
                foreach (var node in nodeCategory.Value.Values)
                {
                    if (!node.Name.ToLower().Contains(SearchBuffer.ToLower()))
                        continue;

                    sorted.Add(node.Name, node);
                }
            }

            foreach (var node in sorted.Values)
            {
                if (ImGui.Selectable(node.Name, false, ImGuiSelectableFlags.AllowDoubleClick))
                {
                    if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                    {
                        NodesHandling.AddToGraph(node, FixedPos.Value - GraphEditor.WindowPos + GraphEditor.EditorScrollPos);
                        ToggleSelector();
                    }

                }
                Helpers.NodeTooltip(node.Description);
            }

            ImGui.EndChild();
            ImGui.EndChild();
        }
    }
}
