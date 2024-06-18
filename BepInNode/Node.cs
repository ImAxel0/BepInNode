using BepInNode.NodeArguments;
using BepInNode.NodeIO;
using Newtonsoft.Json;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNode;

/// <summary>
/// The main node class from which you should inherit all your new personal nodes
/// </summary>
public class Node
{
    public string Id = Guid.NewGuid().ToString(); // unique id of each node

    [XmlIgnore]
    [JsonIgnore]
    public string Description { get; set; } = string.Empty; // description of the node shown when hovering it in the list or graph

    [XmlIgnore]
    public Vector2 Position { get; set; } // position of the node in the graph

    [XmlIgnore]
    [JsonIgnore]
    public Vector2 SizeOverride { get; set; } = Vector2.Zero; // optional param to override node size

    [XmlIgnore]
    [JsonIgnore]
    public bool IsDragging { get; set; } // true if the node is being moved around in the graph

    [XmlIgnore]
    public string Name { get; set; } = string.Empty; // displayed node name both in list and graph

    [XmlIgnore]
    [JsonIgnore]
    public NodeTypes NodeType = NodeTypes.Middle;

    public enum NodeTypes
    {
        Starter, // doesn't have an input, only have an output
        Middle, // has both input and output
        Flow,
        Variable, // custom type for variable nodes handling
    }

    [XmlIgnore]
    [JsonIgnore]
    public NodeCategories NodeCategory = NodeCategories.Misc;

    public enum NodeCategories
    {
        Misc,
        GameObject,
        Transform,
        MonoBehaviour,
        Input,
        Math,
        Vector2,
        Vector3,
        TypeUtility,
        Fields,
        Properties,
        BepInEx,
        Rigidbody,
        Physics,
        SceneManager,
        Flow,
        Events,
        Methods,
        Camera,
        Variables,
    }

    [XmlIgnore]
    /// <summary>
    /// Informations about the Input of the node
    /// </summary>
    public InputNode Input = new();

    [XmlIgnore]
    /// <summary>
    /// Informations about the Outputs of the node
    /// </summary>
    public List<OutputNode> Outputs = new()
    {
        new OutputNode()
    };

    [XmlArray("ArgsIn"), XmlArrayItem(typeof(ArgIn))]
    /// <summary>
    /// Informations about the input arguments of the node
    /// </summary>
    public List<ArgIn> ArgsIn = new();

    [XmlArray("ArgsOut"), XmlArrayItem(typeof(ArgOut))]
    /// <summary>
    /// Informations about the output arguments of the node
    /// </summary>
    public List<ArgOut> ArgsOut = new();
}
