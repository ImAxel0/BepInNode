using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Flow;

public class WaitUntil : Node
{
	public bool Condition { get; set; }

	public WaitUntil()
	{
		Name = $"WaitUntil {FontAwesome6.HourglassHalf}";
		Description = "Waits for Condition to be true";
		NodeType = NodeTypes.Flow;
		NodeCategory = NodeCategories.Flow;
		SizeOverride = new(200, 150);

		ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Condition) });
	}
}

