using BepInNode.Core;
using BepInNode.Core.Project;
using BepInNode.Core.Runtime;
using BepInNode.Graph;
using BepInNode.Utilities.FileDialogs;
using ImGuiNET;

namespace BepInNode.Utilities
{
    public class ShortcutHelper
    {
        public static void ListenForShortcuts()
        {
            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.O, false))
            {
                var dialog = new OpenFileDialog()
                {
                    Title = "Select a project file",
                    Filter = "Json files (*.nodeproj)|*.nodeproj"
                };
                dialog.ShowOpenFileDialog();

                if (dialog.Success)
                {
                    var file = new FileInfo(dialog.Files.First());
                    ProjectData.LoadProject(file.FullName);
                }
                return;
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.A, false))
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
                    ProjectData.SaveProjectAt(saveFileDialog.FileName, projectData);
                }
                return;
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.S, false))
            {
                ProjectData projectData = new()
                {
                    GraphNodes = GraphEditor.GraphNodes,
                    GraphComments = GraphEditor.GraphComments,
                    VariablesId = VariablesManager.VariablesId,
                    Variables = VariablesManager.Variables
                };
                ProjectData.SaveProject(projectData);
                return;
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.N, false))
            {
                ProjectData.CreateNewProject();
                return;
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.B, false))
            {
                ProjectDialogBuild.ShowDialog = true;
                return;
            }

            if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGuiKey.E, false))
            {
                PipeManager.ExecuteMod();
                return;
            }

            if (ImGui.GetIO().KeyShift && ImGui.IsKeyPressed(ImGuiKey._1, false))
                NodeList._selectedTab = NodeList.Tabs.Variables;

            if (ImGui.GetIO().KeyShift && ImGui.IsKeyPressed(ImGuiKey._2, false))
                NodeList._selectedTab = NodeList.Tabs.Log;
        }
    }
}
