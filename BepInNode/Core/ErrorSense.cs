using BepInNode.CustomAttributes;
using BepInNode.Graph;
using BepInNode.Nodes.Events;

namespace BepInNode.Core;

public class ErrorSense
{
    public static Tuple<bool, string> CheckCustomEvents(IEnumerable<Node> customEventNodes, IEnumerable<Node> callCustomEventNodes)
    {
        List<string> cEventsNames = new();

        foreach (var ev in customEventNodes)
        {
            CustomEvent cEv = (CustomEvent)ev;
            if (customEventNodes.Any(x => (string)x.GetType().GetProperty("EventName").GetValue(x) == cEv.EventName && cEv != x))
                return new(false, $"A {cEv.Name} node has the same EventName as another one");
        }

        foreach (var callEventNode in callCustomEventNodes)
        {
            var callEvent = (CallCustomEvent)callEventNode;
            if (callEvent.Input.HasConnection && string.IsNullOrEmpty(callEvent.EventName))
                return new(false, $"A {callEvent.Name} node doesn't have an EventName");
        }

        foreach (var customEvent in customEventNodes)
        {
            var cEvent = (CustomEvent)customEvent;
            cEventsNames.Add(cEvent.EventName);

            if (string.IsNullOrEmpty(cEvent.EventName))
                return new(false, $"A {cEvent.Name} node doesn't have an EventName");
        }

        foreach (var node in GraphEditor.GraphNodes)
        {
            var property = node.GetType().GetProperties().FirstOrDefault(p => p.CustomAttributes.Any(at => at.AttributeType == typeof(IsEventName)));

            if (property == null)
                continue;

            if (node.Input.HasConnection && !cEventsNames.Contains(property.GetValue(node)))
                return new(false, $"A {node.Name} node doesn't have a matching CustomEvent EventName");
        }
        return new(true, string.Empty);
    }
}
