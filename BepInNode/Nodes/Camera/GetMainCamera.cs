namespace BepInNode.Nodes.Camera;

public class GetMainCamera : Node
{
    public GetMainCamera()
    {
        Name = nameof(GetMainCamera);
        Description = "Returns the camera tagged \"MainCamera\" and its transform";
        NodeCategory = NodeCategories.Camera;
        SizeOverride = new(250, 140);

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.Camera) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
