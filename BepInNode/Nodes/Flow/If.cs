using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using BepInNode.NodeIO;
using IconFonts;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Flow;
public class If : Node
{
    public bool Value { get; set; }

    [XmlArray("TrueBranch")]
    [XmlArrayItem("Node", typeof(Node))]
    [IgnoreProperty]
    public List<Node> TrueBranchNodes { get; set; } = new List<Node>();

    [XmlArray("FalseBranch")]
    [XmlArrayItem("Node", typeof(Node))]
    [IgnoreProperty]
    public List<Node> FalseBranchNodes { get; set; } = new List<Node>();

    public If()
    {
        Name = $"If {FontAwesome6.CodeBranch}";
        Description = "If condition is true go to 1 (first output), else go to 2 (second output)";
        NodeType = NodeTypes.Flow;
        NodeCategory = NodeCategories.Flow;
        SizeOverride = new(200, 180);

        Outputs.Add(new OutputNode());

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
    }
}
