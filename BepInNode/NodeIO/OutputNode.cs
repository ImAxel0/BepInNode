using BepInNode.Core;
using BepInNode.Graph;
using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;

namespace BepInNode.NodeIO
{
    public class OutputNode
    {
        /// <summary>
        /// The node of this output
        /// </summary>
        public Node Node { get; set; }

        [JsonIgnore]
        static float _radius = 7;

        public Vector2 Position { get; set; }

        [JsonIgnore]
        public bool IsDragging;

        /// <summary>
        /// Is this output connected to another one?
        /// </summary>
        public bool HasConnection;

        /// <summary>
        /// The node connected to this Output (aka the next node)
        /// </summary>
        public Node NextNode { get; set; }

        public void Render(Node node)
        {
            Node = node;
            Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
            Position = new Vector2(cursorScreenPos.X + _radius, cursorScreenPos.Y + _radius);

            if (Helpers.IsMouseHoveringRadius(Position, _radius))
            {
                ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                Drawings.DrawOutlineGlow(_radius, 0.5f, ImGui.GetColorU32(new Vector4(1, 1, 1, 0.1f)));
            }

            if (HasConnection)
            {
                Drawings.DrawFilledCircle(_radius, ImGui.GetColorU32(ImGuiTheme.Colors.White), 1);

                if (Helpers.IsMouseHoveringRadius(Position, _radius) && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Right))
                    NodesHandling.DisconnectNode(this, NextNode.Input);
            }
            else Drawings.DrawEmptyCircle(_radius, ImGui.GetColorU32(ImGuiTheme.Colors.White), 1);

            if (ImGui.IsMouseDown(ImGuiMouseButton.Right) && !IsDragging && !GraphEditor.DraggingOutput && !GraphEditor.IsPanning)
                GraphEditor.DraggingOutput = IsDragging = ImGui.IsMouseDown(ImGuiMouseButton.Right) && Helpers.IsMouseHoveringRadius(Position, _radius);

            else if (!ImGui.IsMouseDown(ImGuiMouseButton.Right) && IsDragging)
                GraphEditor.DraggingOutput = IsDragging = false;
        }
    }
}
