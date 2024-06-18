using BepInNode.Core;
using BepInNode.Graph;
using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNode.NodeArguments;

public class ArgOut
{
    [XmlIgnore]
    /// <summary>
    /// The node of this output argument
    /// </summary>
    public Node Node { get; set; }

    [XmlIgnore]
    /// <summary>
    /// To which node is this output argument connected
    /// </summary>
    public Node ConnectedNode { get; set; }

    [XmlIgnore]
    public Vector2 Position { get; set; }

    [XmlIgnore]
    public bool IsDragging;

    [XmlIgnore]
    /// <summary>
    /// Is this output argument connected to an input argument?
    /// </summary>
    public bool HasConnection;

    [XmlIgnore]
    [JsonIgnore]
    public float Radius = 7;

    [XmlIgnore]
    /// <summary>
    /// The input argument to which this output argument is connected
    /// </summary>
    public ArgIn InputArg { get; set; }

    [XmlIgnore]
    public Type Type { get; set; }

    public string PassTo { get; set; }

    public void Render(Node node)
    {
        Node = node;
        Position = new Vector2(ImGui.GetCursorScreenPos().X + Radius, ImGui.GetCursorScreenPos().Y + Radius);

        if (HasConnection && Helpers.IsMouseHoveringRadius(Position, Radius) && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Right))
            NodesHandling.DisconnectArgs(this, InputArg);

        Helpers.InOutTooltip(Helpers.IsMouseHoveringRadius(Position, Radius), Type.Name);

        var typeColor = ImGuiTheme.Colors.GetTypeColor(Type);

        if (Helpers.IsMouseHoveringRadius(Position, Radius))
        {
            ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
            Drawings.DrawOutlineGlow(Radius, 1f, ImGui.GetColorU32(new Vector4(typeColor.X, typeColor.Y, typeColor.Z, 0.1f)));
        }

        if (HasConnection)
            Drawings.DrawFilledCircle(Radius, ImGui.GetColorU32(typeColor));
        else
            Drawings.DrawEmptyCircle(Radius, ImGui.GetColorU32(typeColor));

        if (ImGui.IsMouseDown(ImGuiMouseButton.Right) && !IsDragging && !GraphEditor.DraggingOutput && !GraphEditor.IsPanning)
            GraphEditor.DraggingOutput = IsDragging = ImGui.IsMouseDown(ImGuiMouseButton.Right) && Helpers.IsMouseHoveringRadius(Position, Radius);

        else if (!ImGui.IsMouseDown(ImGuiMouseButton.Right) && IsDragging)
            GraphEditor.DraggingOutput = IsDragging = false;
    }
}
