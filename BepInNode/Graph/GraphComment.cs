using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;

namespace BepInNode.Graph
{
    public class GraphComment
    {
        public Vector2 P1 { get; set; }
        public Vector2 P2 { get; set; }

        public string Text = "Comment";

        public Vector4 BgColor = new(.6f, .6f, .6f, 0.1f);

        [JsonIgnore]
        public bool IsResizing;

        [JsonIgnore]
        public bool IsDragging;

        public bool IsCreation = true;

        public void Render()
        {
            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = BgColor;
            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = BgColor * 1.2f;

            ImGui.PushFont(FontController.GetFontOfSize(20));
            ImGui.PushID(GetHashCode());

            var size = new Vector2(P2.X - P1.X, P2.Y - P1.Y);

            var rectStart = P1 * GraphEditor.Zoom + GraphEditor.WindowPos - GraphEditor.EditorScrollPos;
            var rectEnd = P2 * GraphEditor.Zoom + GraphEditor.WindowPos - GraphEditor.EditorScrollPos;

            ImGui.SetCursorPos(P1 * GraphEditor.Zoom);
            ImGui.BeginChild("##", size * GraphEditor.Zoom);
            ImGui.SetWindowFontScale(GraphEditor.Zoom);

            var inputHeight = ImGui.GetFrameHeight();
            ImGui.SetNextItemWidth(rectEnd.X - rectStart.X - inputHeight);
            ImGui.SetCursorScreenPos(rectStart);
            ImGui.InputText("##commentText", ref Text, 1000);
            if (IsCreation)
            {
                ImGui.SetKeyboardFocusHere(-1);
                IsCreation = false;
            }

            ImGui.SetCursorScreenPos(rectStart + new Vector2(rectEnd.X - rectStart.X - inputHeight, 0));
            ImGui.ColorEdit4("##commentColor", ref BgColor, ImGuiColorEditFlags.NoAlpha | ImGuiColorEditFlags.NoOptions |
                ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.NoSidePreview | ImGuiColorEditFlags.PickerHueWheel);

            if (ImGui.IsItemHovered(ImGuiHoveredFlags.RectOnly) && ImGui.IsMouseDown(ImGuiMouseButton.Right))
                IsDragging = true;
            else if (ImGui.IsMouseReleased(ImGuiMouseButton.Right) || !GraphEditor.IsEditorHovered)
                IsDragging = false;

            if (IsDragging)
            {
                P1 += ImGui.GetIO().MouseDelta / GraphEditor.Zoom;
                P2 += ImGui.GetIO().MouseDelta / GraphEditor.Zoom;
            }

            ImGui.EndChild();

            if (ImGui.IsMouseHoveringRect(rectStart + new Vector2(0, inputHeight), rectEnd)
                && ImGui.IsMouseDown(ImGuiMouseButton.Left) && !GraphEditor.DraggingNode && !GraphEditor.DraggingOutput && !IsResizing)
            {
                ImGui.GetWindowDrawList().AddRectFilled(rectStart, rectEnd, ImGui.GetColorU32(BgColor), 5);
                if (ImGui.IsKeyPressed(ImGuiKey.Delete, false))
                    GraphEditor.GraphComments.Remove(this);
            }

            ImGui.GetWindowDrawList().AddTriangleFilled(rectEnd, rectEnd + new Vector2(-10, 0), rectEnd + new Vector2(0, -10), ImGui.GetColorU32(new Vector4(1, 1, 1, .5f)));
            if (Helpers.IsMouseHoveringRadius(rectEnd - new Vector2(2.5f, 2.5f), 7) && !GraphEditor.DraggingNode && !GraphEditor.DraggingOutput && !IsResizing)
            {
                ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeNWSE);
                IsResizing = ImGui.IsMouseClicked(ImGuiMouseButton.Left);
            }
            else if (ImGui.IsMouseReleased(ImGuiMouseButton.Left))
                IsResizing = false;

            if (IsResizing)
            {
                ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeNWSE);
                P2 += ImGui.GetIO().MouseDelta / GraphEditor.Zoom;
            }

            ImGui.PopID();
            ImGui.PopFont();
        }

        public static void RenderRectPreview(Vector2 p1)
        {
            ImGui.GetWindowDrawList().AddRectFilled(p1, ImGui.GetIO().MousePos, ImGui.GetColorU32(new Vector4(1, 1, 1, 0.05f)), 5);
        }

    }
}