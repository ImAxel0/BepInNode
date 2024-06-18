using BepInNode.Core.Project;
using BepInNode.Core.Runtime;
using BepInNode.Graph;
using BepInNode.Utilities;
using BepInNode.Utilities.FileDialogs;
using IconFonts;
using ImGuiNET;

namespace BepInNode.Core;

public class MenuBar
{
    public static string ShortcutInfo =
    "CTRL+N = NEW PROJECT\n" +
    "CTRL+O = OPEN PROJECT\n" +
    "CTRL+S = SAVE PROJECT\n" +
    "CTRL+A = SAVE PROJECT AT\n" +
    "CTRL+B = BUILD PROJECT\n" +
    "------------------------------------------------\n" +
    "F11 = FULLSCREEN MODE\n" +
    "------------------------------------------------\n" +
    "DELETE = DELETE NODE\n" +
    "CTRL+D = DUPLICATE NODE\n" +
    "CTRL+LMB+DRAG = CREATE COMMENT\n" +
    "CTRL+MOUSE WHEEL = ZOOM IN/OUT\n" +
    "F1 = QUICK NODE SELECTOR";

    public static void Render()
    {
        ImGui.BeginMenuBar();

        ImGui.TextDisabled(ProjectData.ProjectName.Replace(".nodeproj", string.Empty));

        if (ImGui.BeginMenu($"{FontAwesome6.File} File"))
        {
            if (ImGui.MenuItem("New Project", "Ctrl+N"))
            {
                ProjectData.CreateNewProject();
            }

            if (ImGui.MenuItem("Open Project", "Ctrl+O"))
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
            }

            if (ImGui.MenuItem("Save Project", "Ctrl+S"))
            {
                ProjectData projectData = new()
                {
                    GraphNodes = GraphEditor.GraphNodes,
                    GraphComments = GraphEditor.GraphComments,
                    VariablesId = VariablesManager.VariablesId,
                    Variables = VariablesManager.Variables
                };
                ProjectData.SaveProject(projectData);
            }

            if (ImGui.MenuItem("Save Project As", "Ctrl+Shift+S"))
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
            }
            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.ArrowsToEye} View"))
        {
            ImGui.Checkbox("Hide Inputs/Outputs in node list", ref NodeList.HideArguments);
            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.Code} Build"))
        {
            if (ImGui.MenuItem("Build project", "Ctrl+B"))
            {
                ProjectDialogBuild.ShowDialog = true;
            }
            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.FileExport} Runtime"))
        {
            if (ImGui.MenuItem("Execute mod", "Ctrl+E"))
            {
                PipeManager.ExecuteMod();
            }
            Helpers.NodeTooltip("Directly execute the node connections while in game.\nGame must be running and BepInNodeLoader installed");

            if (ImGui.MenuItem("Stop execution"))
            {
                PipeManager.StopExecution();
            }

            ImGui.EndMenu();
        }

        if (ImGui.BeginMenu($"{FontAwesome6.CircleInfo} Help"))
        {
            ImGui.Text("Shortcuts");
            Helpers.NodeTooltip(ShortcutInfo);

            ImGui.EndMenu();
        }
        if (ImGui.BeginMenu($"{FontAwesome6.CircleUser} About"))
        {
            AboutDialog.ShowDialog = true;
            ImGui.EndMenu();
        }
        ImGui.EndMenuBar();
    }
}
