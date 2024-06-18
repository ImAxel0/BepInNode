namespace BepInNode.Nodes.Rigidbody;

public class RbGetMass : Node
{
    public RbGetMass()
    {
        Name = nameof(RbGetMass);
        Description = "Returns the mass of the rigidbody.";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(float) });
    }
}
