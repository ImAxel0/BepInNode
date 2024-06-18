using BepInNode.Core.Project;
using BepInNode.Utilities;
using System.Reflection;
using static BepInNode.Node;

namespace BepInNode.Core
{
    public class ProgramData
    {
        public static readonly string AppVersion = "0.1.0";
        public static readonly string ProjectExtension = ".nodeproj";
        public static readonly string ModExtension = ".nodemod";

        public static void InitializeProgram()
        {
            ImageController.LoadImage("BepLogo");
            List<Type> nodeTypes = Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .Where(t => typeof(Node).IsAssignableFrom(t) && t.IsClass && t.IsSubclassOf(typeof(Node)))
                       .ToList();

            Logger.Append("Loading nodes...");
            foreach (Type nodeType in nodeTypes)
            {
                Node node = Activator.CreateInstance(nodeType) as Node;

                if (node != null)
                {
                    if (node.NodeType == NodeTypes.Variable)
                        continue;

                    foreach (NodeCategories enumValue in Enum.GetValues(typeof(NodeCategories)))
                    {
                        if (node.NodeCategory == enumValue)
                        {
                            NodeList.CategoryNodesPair[node.NodeCategory].Add(node.Name, node);
                            Logger.Append($"    Loading [{node.Name}]");
                        }
                    }
                }
            }
            Logger.Append($"All {nodeTypes.Count} nodes loaded!\n");
            ProgramSettings.LoadSettings();
            ProjectData.CreateNewProject();
        }
    }
}
