using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get;

public class TransformGet : Node
{
    public TransformGet()
    {
        Name = "TransformGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the Transform variable";
        NodeCategory = NodeCategories.Variables;

        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
