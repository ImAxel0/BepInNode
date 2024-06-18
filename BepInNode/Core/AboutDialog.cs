using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using System.Diagnostics;
using System.Numerics;

namespace BepInNode.Core;

public class AboutDialog
{
    public static bool ShowDialog;

    public static void Render()
    {
        if (!ShowDialog)
            return;

        ImGuiTheme.ImGuiStyle.WindowRounding = 5;
        ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.PopupBg] = new Vector4(0.12f, 0.12f, 0.12f, 1f);
        ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.Button] = ImGuiTheme.Colors.SelectedNodeColor;

        ImGui.OpenPopup($"About");
        ImGui.SetNextWindowSize(new(600, 400));
        ImGui.SetNextWindowPos(ImGui.GetIO().DisplaySize / 2 - new Vector2(300, 200));
        ImGui.PushFont(FontController.GetFontOfSize(20));
        ImGui.BeginPopupModal($"About", ref ShowDialog, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove);
        ImGui.PopFont();

        ImGui.SetCursorPosX(ImGui.GetWindowSize().X / 2 - 125);

        ImGui.Image(ImageController.GetImageByName("BepLogo"), new(250, 250));
        if (ImGui.IsItemHovered())
        {
            ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
            if (ImGui.IsMouseClicked(ImGuiMouseButton.Left, false))
            {
                Process.Start(new ProcessStartInfo("https://github.com/ImAxel0/BepInNode") { UseShellExecute = true });
            }
        }        

        ImGui.BeginChild("AppInfoWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

        ImGui.PushFont(FontController.GetFontOfSize(48));
        ImGui.SetCursorPos(ImGui.GetWindowSize() / 2 - ImGui.CalcTextSize($"{ProgramData.AppVersion}") / 2);
        ImGui.TextColored(ImGuiTheme.Colors.Brown, $"{ProgramData.AppVersion}");
        ImGui.PopFont();

        ImGui.EndChild();

        ImGui.EndPopup();

        ImGuiTheme.ApplyTheme();
    }
}
