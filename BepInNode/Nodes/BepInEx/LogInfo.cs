namespace BepInNode.Nodes.BepInEx;

public class LogInfo : Node
{
    public string Message { get; set; } 

    public LogInfo()
    {
        Name = nameof(LogInfo);
        Description = "Prints a console message";
        NodeCategory = NodeCategories.BepInEx;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(Message) });
    }
}
