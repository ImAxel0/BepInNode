using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Input;

public class GetAxis : Node
{
    public string AxisName { get; set; }

    public GetAxis()
    {
        Name = nameof(GetAxis);
        Description = "Returns a value between -1 and 1 for keyboard and joystick input devices." +
            " For the mouse it will return the current mouse delta multiplied by the axis sensitivity";
        NodeCategory = NodeCategories.Input;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(AxisName) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
