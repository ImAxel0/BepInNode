using BepInNode.Graph;
using BepInNode.Nodes.BepInEx;
using BepInNode.Nodes.MonoBehaviour;
using BepInNode.Utilities;
using BepInNode.Utilities.FileDialogs;
using Newtonsoft.Json;
using System.Numerics;
using Vanara.PInvoke;

namespace BepInNode.Core.Project
{
    public class ProjectData
    {
        public static string ProjectName = "unsaved";
        public static string LastOpenedPath = string.Empty;
        public List<Node> GraphNodes = new();
        public List<GraphComment> GraphComments = new();
        public List<string> VariablesId = new();
        public Dictionary<string, Type> Variables = new();

        public static bool SaveProjectAt(string filePath, ProjectData project)
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                MaxDepth = 128,
            };

            string json = JsonConvert.SerializeObject(project, settings);
            LastOpenedPath = filePath;

            try
            {
                File.WriteAllText(filePath, json);
                Logger.Append($"Project saved at: {filePath}");
            }
            catch (Exception ex)
            {
                User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error saving the project",
                    User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
                return false;
            }
            ProjectName = Path.GetFileName(filePath);
            return true;
        }

        public static void SaveProject(ProjectData project)
        {
            if (ProjectName == "unsaved")
            {
                var saveFileDialog = new SaveFileDialog();
                bool result = saveFileDialog.ShowDialog(filter: "Json file (*.nodeproj)\0*.nodeproj", title: "Save project");

                if (result)
                {
                    ProjectData projectData = new()
                    {
                        GraphNodes = GraphEditor.GraphNodes,
                        GraphComments = GraphEditor.GraphComments,
                        VariablesId = VariablesManager.VariablesId,
                        Variables = VariablesManager.Variables
                    };
                    SaveProjectAt(saveFileDialog.FileName, projectData);
                }
                return;
            }

            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                MaxDepth = 128,
            };

            string json = JsonConvert.SerializeObject(project, settings);
            var filePath = LastOpenedPath;

            try
            {
                File.WriteAllText(filePath, json);
                Logger.Append($"Project saved at: {filePath}");
            }
            catch (Exception ex)
            {
                User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error saving the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
            }
        }

        public static bool LoadProject(string filePath)
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                MaxDepth = int.MaxValue,
            };

            string json = File.ReadAllText(filePath);
            LastOpenedPath = filePath;

            try
            {
                var projectData = JsonConvert.DeserializeObject<ProjectData>(json, settings);
                GraphEditor.GraphNodes = projectData.GraphNodes;
                GraphEditor.GraphComments = projectData.GraphComments;
                VariablesManager.VariablesId = projectData.VariablesId;
                VariablesManager.Variables = projectData.Variables;
                ProjectName = Path.GetFileName(filePath);
                GraphEditor.EditorScrollPos = Vector2.Zero;
                Logger.Append($"Project loaded from: {filePath}");
            }
            catch (Exception ex)
            {
                User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error loading the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
                return false;
            }
            return true;
        }

        public static void CreateNewProject()
        {
            NodesHandling.DeleteAllNodes();
            GraphEditor.GraphComments.Clear();
            VariablesManager.VariablesId.Clear();
            VariablesManager.Variables.Clear();

            GraphEditor.GraphNodes.Add(new OnLoad() { Position = new(20, 100) });
            GraphEditor.GraphNodes.Add(new Update() { Position = new(20, 400) });
            GraphEditor.GraphNodes.Add(new FixedUpdate() { Position = new(20, 700) });
            GraphEditor.EditorScrollPos = Vector2.Zero;
            ProjectName = "unsaved";
        }
    }
}
