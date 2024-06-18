namespace BepInNode.Nodes.BepInEx;

public class LogWarning : Node
{
    public string Message { get; set; }

    public LogWarning()
    {
        Name = nameof(LogWarning);
        Description = "Prints a console warning message";
        NodeCategory = NodeCategories.BepInEx;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(Message) });
    }
}
