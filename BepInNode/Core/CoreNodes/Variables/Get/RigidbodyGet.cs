using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get;

public class RigidbodyGet : Node
{
    public RigidbodyGet()
    {
        Name = "RigidbodyGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the Rigidbody variable";
        NodeCategory = NodeCategories.Variables;

        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Rigidbody) });
    }
}
