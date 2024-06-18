using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Events;

public class CallCustomEvent : Node
{
    [IgnoreProperty]
    public string EventId { get; set; }

    [IsEventName]
    public string EventName { get; set; }

    public CallCustomEvent()
    {
        Name = $"CallCustomEvent {FontAwesome6.Phone}";
        Description = "Calls a custom event by its event name";
        NodeCategory = NodeCategories.Events;
        SizeOverride = new(270, 130);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
    }
}
