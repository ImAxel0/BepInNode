using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Flow;

public class RepeatUntil : Node
{
	public bool Condition { get; set; }
	private float _delay = 10f; // 10 millisecond default delay
	public float DelayMs
	{ 
		get => _delay; 
		set => _delay = System.Math.Max(value, 0f);
	}


	public RepeatUntil()
	{
		Name = $"RepeatUntil {FontAwesome6.Repeat}";
		Description = "Repeats logic until condition met, (Delay in Milliseconds, Default value of 10ms)";
		NodeType = NodeTypes.Flow;
		NodeCategory = NodeCategories.Flow;
		SizeOverride = new(220, 210);

		ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Condition) });
		ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(DelayMs) });
	}
}

