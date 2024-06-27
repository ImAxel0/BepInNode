using BepInNode.Core;
using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using System.Numerics;

namespace BepInNode.Graph
{
    public class GraphEditor
    {
        public static List<Node> GraphNodes = new(); // List of nodes placed in the editor, connected and unconnected
        public static List<GraphComment> GraphComments = new(); // List of comments placed in the editor
        public static Vector2 EditorScrollPos = new();
        public static Vector2 CurrentEditorWinSize = new();
        public static Vector2 WindowPos = new();
        public static bool IsEditorHovered;
        public static bool DraggingNode;
        public static bool DraggingOutput;
        public static bool IsPanning;
        public static float Zoom = 1f;
        public static Node SelectedNode;
        public static Vector2 SelectedNodeSize;
        public static float PanSpeed = 10f;
        public static float GridSize = 50f;

        private static Vector2 _gridOffset = Vector2.Zero;
        private static Vector4 _gridColor = new(1, 1, 1, 0.08f);
        private static float _gridThickness = 1;
        private static Vector2? _commentPreviewStart;
        private static Vector2 _commentPreviewEnd;

        private static void DrawGrid()
        {
            Vector2 windowSize = ImGui.GetIO().DisplaySize;
            Vector2 canvasSize = windowSize + EditorScrollPos;

            var drawList = ImGui.GetWindowDrawList();

            for (float x = _gridOffset.X; x < canvasSize.X; x += GridSize * Zoom)
            {
                drawList.AddLine(new Vector2(x, 0), new Vector2(x, canvasSize.Y), ImGui.GetColorU32(_gridColor), _gridThickness);
            }

            for (float y = _gridOffset.Y; y < canvasSize.Y; y += GridSize * Zoom)
            {
                drawList.AddLine(new Vector2(0, y), new Vector2(canvasSize.X, y), ImGui.GetColorU32(_gridColor), _gridThickness);
            }
        }

        private static void PanVisual()
        {
            IsPanning = true;
            ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeAll);
            EditorScrollPos -= ImGui.GetIO().MouseDelta / 10 * PanSpeed;
        }

        static void ShortcutLisener()
        {
            if (ImGui.IsKeyPressed(ImGuiKey.Delete, false) && !DraggingOutput)
            {
                if (SelectedNode != null)
                {
                    NodesHandling.DeleteNode(SelectedNode);
                    SelectedNode = null;
                }
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.D, false) && !DraggingOutput)
            {
                if (SelectedNode != null)
                {
                    NodesHandling.DuplicateNode(SelectedNode);
                    SelectedNode = null;
                }
            }

            if (ImGui.GetIO().KeyShift && (ImGui.IsKeyPressed(ImGuiKey.A, false)) && IsEditorHovered && !DraggingOutput && !DraggingNode)
                QuickNodeSelector.ToggleSelector();

            if (ImGui.IsMouseDown(ImGuiMouseButton.Middle))
                PanVisual();
            else IsPanning = false;

            if (ImGui.GetIO().KeyCtrl && ImGui.GetIO().MouseWheel != 0 && IsEditorHovered)
                Zoom = System.Math.Clamp(Zoom + ImGui.GetIO().MouseWheel * Zoom / (10 * Zoom), 0.6f, 1f);

            if (ImGui.IsMouseReleased(ImGuiMouseButton.Left) && _commentPreviewStart != null)
            {
                var size = _commentPreviewEnd - _commentPreviewStart;

                if (size.Value.X > 100 && size.Value.Y > 100)
                    GraphComments.Add(new GraphComment
                    {
                        P1 = (_commentPreviewStart.Value - WindowPos + EditorScrollPos) / Zoom,
                        P2 = (_commentPreviewEnd - WindowPos + EditorScrollPos) / Zoom
                    });
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsMouseDown(ImGuiMouseButton.Left) && IsEditorHovered && !DraggingOutput && !DraggingNode)
                _commentPreviewStart ??= ImGui.GetIO().MousePos;
            else _commentPreviewStart = null;
        }

        public static void Render()
        {
            ImGuiTheme.EditorTheme();

            IsEditorHovered = ImGui.IsMouseHoveringRect(WindowPos, WindowPos + CurrentEditorWinSize);

            ImGui.SetNextWindowScroll(EditorScrollPos);
            ImGui.BeginChild("EditorWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border,
                 ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);
            CurrentEditorWinSize = ImGui.GetWindowSize();

            EditorScrollPos = new Vector2(ImGui.GetScrollX(), ImGui.GetScrollY());

            GraphEditorMenuBar.Render(ref GridSize, ref PanSpeed);
            DrawGrid();

            DraggingNode = GraphNodes.Any(x => x.IsDragging);

            ImGuiTheme.CommentTheme();
            foreach (var comment in GraphComments.ToList())
                comment.Render();

            if (_commentPreviewStart != null)
            {
                GraphComment.RenderRectPreview(_commentPreviewStart.Value);
                _commentPreviewEnd = ImGui.GetIO().MousePos;
                ImGui.SetMouseCursor(ImGuiMouseCursor.ResizeNWSE);
            }

            int index = 0;
            foreach (var node in GraphNodes.ToList())
            {
                NodeRenderer.RenderNode(node, index);
                index++;
            }

            ShortcutLisener();

            if (QuickNodeSelector.ShowSelector)
                QuickNodeSelector.Render();

            ImGui.SetCursorScreenPos(new Vector2(ImGui.GetIO().DisplaySize.X - 150, ImGui.GetIO().DisplaySize.Y - 140));
            ImGui.Image(ImageController.GetImageByName("BepLogo"), new(100), Vector2.Zero, Vector2.One, new(1, 1, 1, .5f));

            ImGui.Dummy(new(1000000, 1000000));
            ImGuiTheme.ApplyTheme();
            ImGui.EndChild();
        }
    }
}
