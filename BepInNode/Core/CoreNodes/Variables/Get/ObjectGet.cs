using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class ObjectGet : Node
    {
        public ObjectGet()
        {
            Name = "ObjectGet";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the object variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(object) });
        }
    }
}
