using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;

namespace BepInNode.NodeIO
{
    public class InputNode
    {
        /// <summary>
        /// The node of this input
        /// </summary>
        public Node Node { get; set; }

        [JsonIgnore]
        static float _radius = 7;

        public Vector2 Position { get; set; }

        public bool HasConnection;

        /// <summary>
        /// The node connected to this Input (aka the previous node)
        /// </summary>
        public Node PrevNode;

        public void Render(Node node)
        {
            Node = node;
            Position = new Vector2(ImGui.GetCursorScreenPos().X + _radius, ImGui.GetCursorScreenPos().Y + _radius);

            if (Helpers.IsMouseHoveringRadius(Position, _radius))
            {
                Drawings.DrawOutlineGlow(_radius, 0.5f, ImGui.GetColorU32(new Vector4(1, 1, 1, 0.1f)));
                if (HasConnection)
                    ImGui.SetMouseCursor(ImGuiMouseCursor.NotAllowed);
            }

            if (HasConnection)
                Drawings.DrawFilledCircle(_radius, ImGui.GetColorU32(ImGuiTheme.Colors.White), 1);
            else
                Drawings.DrawEmptyCircle(_radius, ImGui.GetColorU32(ImGuiTheme.Colors.White), 1);
        }
    }
}
