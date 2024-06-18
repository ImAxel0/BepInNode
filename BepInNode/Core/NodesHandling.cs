using BepInNode.CustomAttributes;
using BepInNode.Graph;
using BepInNode.NodeArguments;
using BepInNode.NodeIO;
using BepInNode.Nodes.Events;
using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using System.Numerics;
using System.Reflection;

namespace BepInNode.Core;

public class NodesHandling
{
    public static Node AddToGraph(Node node, Vector2 pos)
    {
        if (Helpers.ContainsType(GraphEditor.GraphNodes, node.GetType()) && node.NodeType == Node.NodeTypes.Starter && node.GetType() != typeof(CustomEvent))
            return null;

        var nodeInstance = CreateNewInstance(node);
        nodeInstance.Position = pos / GraphEditor.Zoom;
        GraphEditor.GraphNodes.Add(nodeInstance);
        Logger.Append($"Added [{nodeInstance.Name}] node to graph");
        return nodeInstance;
    }

    private static Node CreateNewInstance(Node originalInstance)
    {
        // Get the type of the original instance
        Type originalType = originalInstance.GetType();

        // Create a new instance of the same type as the original type
        Node newInstance = (Node)Activator.CreateInstance(originalType);

        return newInstance;
    }

    public static void UpdateSelectedNode(out Vector2 pos, out Vector2 size)
    {
        pos = GraphEditor.SelectedNode.Position * GraphEditor.Zoom;
        size = GraphEditor.SelectedNodeSize * GraphEditor.Zoom;
    }

    public static void GetDragInput(Node node)
    {
        node.Outputs.ForEach(output =>
        {
            if (output.IsDragging)
            {
                Drawings.DrawCursor(Drawings.CursorType.InputOutput);
                Drawings.DrawNodeLine(output.Position, ImGui.GetIO().MousePos);

                GraphEditor.GraphNodes.ForEach(graphNode =>
                {

                    if (Helpers.IsMouseHoveringRadius(graphNode.Input.Position, 7) && !graphNode.Input.HasConnection && ImGui.IsMouseClicked(ImGuiMouseButton.Left)) //  && ImGui.IsMouseClicked(ImGuiMouseButton.Left)
                    {
                        GraphEditor.DraggingOutput = output.IsDragging = false;
                        if (!output.HasConnection)
                            ConnectNodes(output, graphNode.Input);
                        else
                            SwapNodes(output, graphNode.Input);

                        Logger.Append($"Connected Output {node.Outputs.IndexOf(output)} of [{node.Name}] to Input of [{graphNode.Name}]");
                    }
                });
            }
        });

        node.ArgsOut.ForEach(ArgOut =>
        {

            if (ArgOut.IsDragging)
            {
                Drawings.DrawCursor(Drawings.CursorType.Argument, ArgOut.Type);
                Drawings.DrawNodeArgumentLine(ArgOut.Position, ImGui.GetIO().MousePos, ImGuiTheme.Colors.GetTypeColor(ArgOut.Type));

                GraphEditor.GraphNodes.ForEach(graphNode =>
                {
                    graphNode.ArgsIn.ForEach(ArgIn =>
                    {

                        if (Helpers.IsMouseHoveringRadius(ArgIn.Position, ArgIn.Radius) && ArgOut.Type != ArgIn.Type && ArgIn.Type != typeof(object))
                            ImGui.SetMouseCursor(ImGuiMouseCursor.NotAllowed);

                        if (Helpers.IsMouseHoveringRadius(ArgIn.Position, ArgIn.Radius) && !ArgIn.HasConnection && ImGui.IsMouseClicked(ImGuiMouseButton.Left) && (ArgOut.Type == ArgIn.Type || ArgIn.Type == typeof(object)))
                        {
                            if (!ArgOut.HasConnection)
                                ConnectArgs(node, graphNode, ArgOut, ArgIn);
                            else
                                SwapArgs(node, graphNode, ArgOut, ArgIn);

                            Logger.Append($"Connected OUT ARG of [{node.Name}] to INPUT ARG of [{graphNode.Name}] as type [{ArgOut.Type.Name}]");
                        }
                    });
                });
            }
        });
    }

    /// <summary>
    /// Populates data between the two connected nodes
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    public static void ConnectNodes(OutputNode first, InputNode second)
    {
        first.HasConnection = second.HasConnection = true;

        first.NextNode = second.Node;
        second.PrevNode = first.Node;
    }

    public static void SwapNodes(OutputNode first, InputNode second)
    {
        DisconnectNode(first, first.NextNode.Input);
        ConnectNodes(first, second);
    }

    public static void DisconnectNode(OutputNode first, InputNode second)
    {
        first.HasConnection = second.HasConnection = false;
        first.NextNode = second.PrevNode = null;
    }

    public static void DisconnectAllNodes()
    {
        foreach (var node in GraphEditor.GraphNodes)
        {
            node.Outputs.ForEach(output =>
            {
                output.HasConnection = false;
                output.NextNode = null;
            });

            node.Input.HasConnection = false;
            node.Input.PrevNode = null;
        }

        Logger.Append("Disconnected all graph nodes");
    }

    public static void ConnectArgs(Node outNode, Node inNode, ArgOut argOut, ArgIn argIn)
    {
        argOut.HasConnection = argIn.HasConnection = true;

        argOut.ConnectedNode = inNode;
        argIn.ConnectedNode = outNode;

        argOut.InputArg = argIn;
        argIn.OutputArg = argOut;

        argOut.PassTo = inNode.Id;
        argIn.ReceiveFrom = outNode.Id;

        argIn.ReceiveFromIndex = outNode.ArgsOut.IndexOf(argOut);
    }

    public static void SwapArgs(Node outNode, Node inNode, ArgOut argOut, ArgIn argIn)
    {
        DisconnectArgs(argOut, argOut.InputArg);
        ConnectArgs(outNode, inNode, argOut, argIn);
    }

    public static void DisconnectArgs(ArgOut argOut, ArgIn argIn)
    {
        if (argOut != null)
        {
            argOut.HasConnection = false;
            argOut.ConnectedNode = null;
            argOut.InputArg = null;
            argOut.PassTo = string.Empty;
        }

        if (argIn != null)
        {
            argIn.HasConnection = false;
            argIn.ConnectedNode = null;
            argIn.OutputArg = null;
            argIn.ReceiveFrom = string.Empty;
            argIn.ReceiveFromIndex = 0;
        }
    }

    public static void DeleteNode(Node node)
    {
        if (node.Input.PrevNode != null)
        {
            node.Input.PrevNode.Outputs.ForEach(output =>
            {
                if (output.NextNode != null)
                {
                    output.NextNode.Input.HasConnection = false;
                    output.NextNode.Input.PrevNode = null;
                }

                output.HasConnection = false;
                output.NextNode = null;
            });
        }

        node.Outputs.ForEach(output =>
        {
            if (output.HasConnection)
            {
                output.NextNode.Input.HasConnection = false;
                output.NextNode.Input.PrevNode = null;
            }
        });

        node.ArgsIn.ForEach(argIn =>
        {
            DisconnectArgs(argIn.OutputArg, argIn);
        });

        node.ArgsOut.ForEach(argOut =>
        {
            DisconnectArgs(argOut, argOut.InputArg);
        });

        GraphEditor.GraphNodes.Remove(node);
        Logger.Append($"Deleted [{node.Name}] node from graph");
    }

    public static void DeleteAllNodes(bool includeBase = true)
    {
        GraphEditor.GraphNodes.ToList().ForEach(node =>
        {

            if (includeBase)
            {
                DeleteNode(node);
            }
            else if (node.NodeType != Node.NodeTypes.Starter)
                DeleteNode(node);
        });
        Logger.Append("Deleted all graph nodes");
    }

    public static void DuplicateNode(Node node)
    {
        if (node.NodeType == Node.NodeTypes.Variable)
            return;

        var copy = CreateNewInstance(node);
        var added = AddToGraph(copy, new(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y));
        if (added != null)
        {
            added.Position = new(node.Position.X + 20, node.Position.Y + 20);
        }
    }

    /// <summary>
    /// Finds the first node in hierarchy of the passed node
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static Node FindBaseNodeOf(Node node)
    {
        if (node.NodeType == Node.NodeTypes.Starter)
            return node;

        var previousNode = node.Input.PrevNode;

        while (previousNode.NodeType != Node.NodeTypes.Starter)
        {
            previousNode = previousNode.Input.PrevNode;

            if (previousNode == null)
                break;
        }
        return previousNode; // the found or not found (null) base node
    }

    /// <summary>
    /// Handles EventName string inputs realtime to search if a corresponding custom event with the same name exist. If it does, sets the EventId of it to the CustomEvent one
    /// </summary>
    /// <param name="node"></param>
    /// <param name="nodeProperties"></param>
    public static void HandleCustomEvents(Node node, IEnumerable<PropertyInfo> nodeProperties)
    {
        var eventNameProp = nodeProperties.FirstOrDefault(p => p.CustomAttributes.Any(at => at.AttributeType == typeof(IsEventName)));

        if (eventNameProp != null)
        {
            var cEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CustomEvent));

            foreach (var cEventNode in cEventNodes)
            {
                var cEvent = (CustomEvent)cEventNode;

                if (cEvent.EventName == (string)eventNameProp.GetValue(node))
                    node.GetType().GetProperty("EventId").SetValue(node, cEvent.EventId);
            }
        }
    }
}
