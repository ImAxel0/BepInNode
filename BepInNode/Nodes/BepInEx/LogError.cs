namespace BepInNode.Nodes.BepInEx;

public class LogError : Node
{
    public string Message { get; set; }

    public LogError()
    {
        Name = nameof(LogError);
        Description = "Prints a console error message";
        NodeCategory = NodeCategories.BepInEx;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(Message) });
    }
}
