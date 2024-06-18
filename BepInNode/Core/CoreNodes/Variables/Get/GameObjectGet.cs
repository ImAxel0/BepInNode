using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get;

public class GameObjectGet : Node
{
    public GameObjectGet()
    {
        Name = "GameObjectGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the GameObject variable";
        NodeCategory = NodeCategories.Variables;

        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.GameObject) });
    }
}
