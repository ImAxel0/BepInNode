using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using CSharpVitamins;
using IconFonts;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Events;

public class CustomEvent : Node
{
    [IgnoreProperty]
    public string EventId { get; set; } = ShortGuid.NewGuid().ToString();
    public string EventName { get; set; }

    [XmlArray("EventNodes")]
    [XmlArrayItem("Node", typeof(Node))]
    [IgnoreProperty]
    public List<Node> EventNodes { get; set; } = new List<Node>();

    public CustomEvent()
    {
        Name = $"CustomEvent {FontAwesome6.ArrowRight}";
        Description = "A custom event which can be called with a CallCustomEvent node";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.Events;
        SizeOverride = new(270, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
    }
}
