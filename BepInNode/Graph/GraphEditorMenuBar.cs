using BepInNode.Core;
using IconFonts;
using ImGuiNET;

namespace BepInNode.Graph
{
    public class GraphEditorMenuBar
    {
        public static void Render(ref float _gridSize, ref float _panSpeed)
        {
            ImGui.BeginMenuBar();

            if (ImGui.BeginMenu($"{FontAwesome6.SquareShareNodes} Nodes"))
            {
                if (ImGui.MenuItem("Disconnect all nodes"))
                {
                    NodesHandling.DisconnectAllNodes();
                }

                if (ImGui.MenuItem("Delete all nodes"))
                {
                    NodesHandling.DeleteAllNodes();
                }

                if (ImGui.MenuItem("Delete all nodes except base ones"))
                {
                    NodesHandling.DeleteAllNodes(false);
                }
                ImGui.EndMenu();
            }

            ImGui.SetNextItemWidth(ImGui.CalcTextSize("Grid size").X);
            ImGui.DragFloat("Grid size", ref _gridSize, 1, 20, 250, "%.0f", ImGuiSliderFlags.AlwaysClamp);
            if (ImGui.IsItemHovered())
                ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeEW);

            ImGui.SetNextItemWidth(ImGui.CalcTextSize("Pan speed").X);
            ImGui.DragFloat("Pan speed", ref _panSpeed, 0.1f, 1f, 20, "%.1f", ImGuiSliderFlags.AlwaysClamp);
            if (ImGui.IsItemHovered())
                ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeEW);

            ImGui.SetCursorPosX(GraphEditor.CurrentEditorWinSize.X / 2 + GraphEditor.EditorScrollPos.X - ImGui.CalcTextSize($"Zoom: {GraphEditor.Zoom:N2}x").X);
            ImGui.TextDisabled($"{FontAwesome6.Eye} Zoom: {GraphEditor.Zoom:N2}x");

            ImGui.EndMenuBar();
        }
    }
}
