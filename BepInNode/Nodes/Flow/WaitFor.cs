using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Flow;

public class WaitFor : Node
{
	public float Seconds
	{
		get => _seconds;
		set => _seconds = System.Math.Max(value, 0);
	}
	private float _seconds;

	public WaitFor()
	{
		Name = $"WaitFor {FontAwesome6.Clock}";
		Description = "Waits for inputted seconds";
		NodeType = NodeTypes.Flow;
		NodeCategory = NodeCategories.Flow;

		ArgsIn.Add(new ArgIn { Type = typeof(float) });
	}
}

