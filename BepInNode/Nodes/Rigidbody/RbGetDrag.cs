namespace BepInNode.Nodes.Rigidbody;

public class RbGetDrag : Node
{
    public RbGetDrag()
    {
        Name = nameof(RbGetDrag);
        Description = "Returns the drag of the object.";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(float) });
    }
}
