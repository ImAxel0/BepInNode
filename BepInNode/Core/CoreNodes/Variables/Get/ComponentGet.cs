using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get;

public class ComponentGet : Node
{
    public ComponentGet()
    {
        Name = "ComponentGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the Component variable";
        NodeCategory = NodeCategories.Variables;

        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Component) });
    }
}
