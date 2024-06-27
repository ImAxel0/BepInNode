using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Flow;

public class WaitUntil : Node
{
	public bool Boolean { get; set; }

	public WaitUntil()
	{
		Name = $"WaitUntil {FontAwesome6.HourglassHalf}";
		Description = "Waits for Boolean to be true";
		NodeType = NodeTypes.Flow;
		NodeCategory = NodeCategories.Flow;

		ArgsIn.Add(new ArgIn { Type = typeof(bool) });
	}
}

