using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Flow;

public class Repeat : Node
{
	public int AmountOfTimes
	{
		get => _amountOfTimes;
		set => _amountOfTimes = System.Math.Max(value, 0);
	}

	private int _amountOfTimes;

	public Repeat()
	{
		Name = $"Repeat {FontAwesome6.Repeat}";
		Description = "Repeats logic";
		NodeType = NodeTypes.Flow;
		NodeCategory = NodeCategories.Flow;
		SizeOverride = new(350, 180);

		ArgsIn.Add(new ArgIn { Type = typeof(int) });
	}
}

