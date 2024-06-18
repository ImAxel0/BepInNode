namespace BepInNode.Nodes.Rigidbody;

public class RbGetAngularDrag : Node
{
    public RbGetAngularDrag()
    {
        Name = nameof(RbGetAngularDrag);
        Description = "Returns the angular drag of the object.";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(float) });
    }
}
