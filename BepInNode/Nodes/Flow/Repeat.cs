using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Flow;

public class Repeat : Node
{
	public int Amount
	{
		get => _amount;
		set => _amount = System.Math.Max(value, 0);
	}

	private int _amount;

	public Repeat()
	{
		Name = $"Repeat {FontAwesome6.Repeat}";
		Description = "Repeats logic";
		NodeType = NodeTypes.Flow;
		NodeCategory = NodeCategories.Flow;
		SizeOverride = new(230, 150);

		ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Amount) });
	}
}

