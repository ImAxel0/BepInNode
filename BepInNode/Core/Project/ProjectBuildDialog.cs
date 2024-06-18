using BepInNode.Style;
using BepInNode.Utilities;
using IconFonts;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace BepInNode.Core.Project;

public class ProjectDialogBuild
{
    public static bool ShowDialog;
    static string _modAuthorBuffer = "";
    static string _modVersionBuffer = "";
    static bool _kbFocus = true;

    public static void Render()
    {
        if (!ShowDialog)
        {
            _modAuthorBuffer = string.Empty;
            _modVersionBuffer = string.Empty;
            _kbFocus = true;
            return;
        }

        if (ProjectData.ProjectName == "unsaved")
        {
            Logger.Append("Error building the mod: project must be saved before building");
            User32.MessageBox(IntPtr.Zero, "Project must be saved before building", "Error building the mod", User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
            ShowDialog = false;
            return;
        }

        ImGui.OpenPopup($"Exporting {ProjectData.ProjectName.Replace(".nodeproj", string.Empty)} mod... {FontAwesome6.FolderOpen}");
        ImGui.SetNextWindowSize(new(600, 180));
        ImGui.SetNextWindowPos(ImGui.GetIO().DisplaySize / 2 - new Vector2(300, 90));
        ImGui.PushFont(FontController.GetFontOfSize(20));
        ImGui.BeginPopupModal($"Exporting {ProjectData.ProjectName.Replace(".nodeproj", string.Empty)} mod... {FontAwesome6.FolderOpen}", ref ShowDialog, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove);
        ImGui.PopFont();

        ImGui.BeginChild("BuildingDialog", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

        ImGui.PushFont(FontController.GetFontOfSize(18));
        ImGui.TextDisabled(ProjectData.ProjectName.Replace(".nodeproj", string.Empty));
        ImGui.PopFont();

        ImGui.Dummy(new(0, 5));

        ImGui.InputTextWithHint("Mod author", "Username", ref _modAuthorBuffer, 1000, ImGuiInputTextFlags.CharsNoBlank);
        if (_kbFocus)
        {
            ImGui.SetKeyboardFocusHere(-1);
            _kbFocus = false;
        }

        ImGui.InputTextWithHint("Mod version", "1.0.0", ref _modVersionBuffer, 1000, ImGuiInputTextFlags.CharsNoBlank | ImGuiInputTextFlags.CharsScientific);

        if (ImGui.Button("Build", ImGui.GetContentRegionAvail()))
        {
            ProjectBuilder.BuildProject(_modAuthorBuffer, _modVersionBuffer);
        }

        ImGui.EndChild();
        ImGui.EndPopup();
    }
}
