using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Methods;

public class CallMethod : Node
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }

    public CallMethod()
    {
        Name = nameof(CallMethod);
        Description = "Calls a method of the passed component which has no parameters";
        NodeCategory = NodeCategories.Methods;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(MethodName) });
    }
}
