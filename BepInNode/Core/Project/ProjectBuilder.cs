using BepInNode.Graph;
using BepInNode.Nodes.BepInEx;
using BepInNode.Nodes.Events;
using BepInNode.Nodes.Flow;
using BepInNode.Nodes.MonoBehaviour;
using BepInNode.Utilities;
using BepInNode.Utilities.FileDialogs;
using Vanara.PInvoke;

namespace BepInNode.Core.Project;

public class ProjectBuilder
{
    private static Dictionary<Type, List<Node>> _basePair = new()
    {
        { typeof(OnLoad), new List<Node>() },
        { typeof(Update), new List<Node>() },
        { typeof(FixedUpdate), new List<Node>() },
        { typeof(CustomEvent), new List<Node> () },
    };

    public static void BuildProject(string modAuthor, string modVersion)
    {
        var modData = ProjectBuilder.MakeModData(modAuthor, modVersion);
        if (modData != null)
        {
            var saveFileDialog = new SaveFileDialog();
            bool result = saveFileDialog.ShowDialog(filter: "Mod file (*.nodemod)\0*.nodemod", title: "Save mod file");
            if (result)
            {
                ProjectSerializer.SerializeModData(saveFileDialog.FileName, modData);
            }
            else
            {
                User32.MessageBox(IntPtr.Zero, "Couldn't export mod file at location", "Error saving mod file",
                    User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
            }
        }
    }

    public static ModData MakeModData(string modAuthor, string modVersion, bool isRuntime = false)
    {
        if (!isRuntime)
        {
            if (string.IsNullOrEmpty(modAuthor))
            {
                Logger.Append("Error building the mod: mod author field can't be empty");
                User32.MessageBox(IntPtr.Zero, "Mod author field can't be empty", "Error building the mod",
                    User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
                return null;
            }

            if (string.IsNullOrEmpty(modVersion))
            {
                Logger.Append("Error building the mod: mod version field can't be empty");
                User32.MessageBox(IntPtr.Zero, "Mod version field can't be empty", "Error building the mod",
                    User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
                return null;
            }
        }

        foreach (var connList in _basePair.Values)
            connList.Clear();

        PopulateConnections();
        if (!PopulateCustomEvents())
            return null;

        if (_basePair.Values.All(x => x.Count <= 1))
        {
            Logger.Append("Error building the mod: no base node was connected");
            User32.MessageBox(IntPtr.Zero, "No base node was connected", "Error building the mod",
                User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
            return null;
        }

        ModData modData = new()
        {
            AppVersion = ProgramData.AppVersion,
            ModName = ProjectData.ProjectName.Replace(".nodeproj", string.Empty),
            ModAuthor = modAuthor,
            ModVersion = modVersion,
            OnLoad = _basePair[typeof(OnLoad)],
            Update = _basePair[typeof(Update)],
            FixedUpdate = _basePair[typeof(FixedUpdate)],
            CustomEvents = _basePair[typeof(CustomEvent)]
        };
        return modData;
    }

    private static void PopulateConnections()
    {
        foreach (var baseType in _basePair.Keys)
        {
            if (baseType == typeof(CustomEvent))
                continue;

            PopulateConnectionsOf(baseType);
        }
    }

    private static void PopulateConnectionsOf(Type baseType)
    {
        var baseNode = GraphEditor.GraphNodes.Find(node => node.GetType() == baseType);

        if (baseNode == null)
            return;

        _basePair[baseType].Add(baseNode);

        var next = baseNode.Outputs[0].NextNode;

        while (next != null)
        {
            if (next.GetType() == typeof(If))
            {
                _basePair[baseType].Add(next);
                PopulateIfStatements(baseType, baseNode);
                break;
            }
            else
            {
                _basePair[baseType].Add(next);
                next = next.Outputs[0].NextNode;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseType"></param>
    /// <param name="baseNode"> Mainly used to distinguish base nodes of the same type as CustomEvents</param>
    private static void PopulateIfStatements(Type baseType, object baseNode)
    {
        var ifNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(If) && NodesHandling.FindBaseNodeOf(node).GetType() == baseType
        && NodesHandling.FindBaseNodeOf(node) == (Node)baseNode);

        foreach (var ifNode in ifNodes)
            PopulateIfStatement(ifNode);
    }

    private static void PopulateIfStatement(Node ifStatementNode)
    {
        If ifNode = (If)ifStatementNode;

        var nextTrue = ifNode.Outputs[0].NextNode;
        var nextFalse = ifNode.Outputs[1].NextNode;

        if (nextTrue != null)
        {
            while (true)
            {
                ifNode.TrueBranchNodes.Add(nextTrue);

                if (nextTrue.GetType() == typeof(If))
                    break;

                nextTrue = nextTrue.Outputs[0].NextNode;

                if (nextTrue == null)
                    break;
            }
        }

        if (nextFalse != null)
        {
            while (true)
            {
                ifNode.FalseBranchNodes.Add(nextFalse);

                if (nextFalse.GetType() == typeof(If))
                    break;

                nextFalse = nextFalse.Outputs[0].NextNode;

                if (nextFalse == null)
                    break;
            }
        }
    }

    private static bool PopulateCustomEvents()
    {
        var customEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CustomEvent));
        var callCustomEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CallCustomEvent));

        var result = ErrorSense.CheckCustomEvents(customEventNodes, callCustomEventNodes);

        if (result.Item1 == false)
        {
            User32.MessageBox(IntPtr.Zero, result.Item2, "Error building the mod", User32.MB_FLAGS.MB_TOPMOST | User32.MB_FLAGS.MB_ICONERROR);
            return false;
        }

        foreach (var customEvent in customEventNodes)
        {
            var cEvent = (CustomEvent)customEvent;

            var nextInEvent = cEvent.Outputs[0].NextNode;

            if (nextInEvent == null) // if no node was connected to the event output
                continue;

            while (true)
            {
                cEvent.EventNodes.Add(nextInEvent);

                if (nextInEvent.GetType() == typeof(If))
                {
                    PopulateIfStatements(cEvent.GetType(), cEvent);
                    break;
                }
                nextInEvent = nextInEvent.Outputs[0].NextNode;
                if (nextInEvent == null)
                    break;
            }
            _basePair[typeof(CustomEvent)].Add(cEvent);
        }
        return true;
    }


    public static void CleanForNextBuild()
    {
        var ifNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(If));
        foreach (var ifNode in ifNodes)
        {
            var node = (If)ifNode;
            node.TrueBranchNodes.Clear();
            node.FalseBranchNodes.Clear();
        }

        var customEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CustomEvent));
        foreach (var customEventNode in customEventNodes)
        {
            var node = (CustomEvent)customEventNode;
            node.EventNodes.Clear();
        }
    }
}
