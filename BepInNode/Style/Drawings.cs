using BepInNode.Graph;
using BepInNode.NodeArguments;
using BepInNode.Utilities;
using ImGuiNET;
using System.Numerics;

namespace BepInNode.Style;

public class Drawings
{
    public static Vector4 LineColor = new(1, 1, 1, 0.8f);
    public static float LineTickness = 2;

    public enum CursorType
    {
        Default,
        InputOutput,
        Argument,
    }

    public static void DrawNodeLine(Vector2 p1, Vector2 p2)
    {
        var dl = ImGui.GetWindowDrawList();
        float distance = (float)System.Math.Sqrt(System.Math.Pow(p2.X - p1.X, 2) + System.Math.Pow(p2.Y - p1.Y, 2));
        float delta = distance * 0.45f;
        if (p2.X < p1.X) delta += 0.2f * (p1.X - p2.X);
        float vert = 0;
        Vector2 p22 = p2 - new Vector2(delta, vert);
        if (p2.X < p1.X - 50f) delta *= -1f;
        Vector2 p11 = p1 + new Vector2(delta, vert);
        dl.AddBezierCubic(p1, p11, p22, p2, ImGui.GetColorU32(LineColor), LineTickness * GraphEditor.Zoom);
    }

    public static void DrawNodeArgumentLine(Vector2 p1, Vector2 p2, Vector4 color)
    {
        var dl = ImGui.GetWindowDrawList();
        float distance = (float)System.Math.Sqrt(System.Math.Pow(p2.X - p1.X, 2) + System.Math.Pow(p2.Y - p1.Y, 2));
        float delta = distance * 0.45f;
        if (p2.X < p1.X) delta += 0.2f * (p1.X - p2.X);
        float vert = 0;
        Vector2 p22 = p2 - new Vector2(delta, vert);
        if (p2.X < p1.X - 50f) delta *= -1f;
        Vector2 p11 = p1 + new Vector2(delta, vert);
        dl.AddBezierCubic(p1, p11, p22, p2, ImGui.GetColorU32(color), (LineTickness - 0.5f) * GraphEditor.Zoom);
    }

    public static void DrawFilledCircle(float radius, uint color, int segments = 50)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + radius * GraphEditor.Zoom, cursorScreenPos.Y + radius);

        ImGui.GetWindowDrawList().AddCircleFilled(center, radius * GraphEditor.Zoom, color, segments);
    }

    public static void DrawEmptyCircle(float radius, uint color, int segments = 50)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + radius * GraphEditor.Zoom, cursorScreenPos.Y + radius);

        ImGui.GetWindowDrawList().AddCircle(center, radius * GraphEditor.Zoom, color, segments);
    }

    public static void DrawOutlineGlow(float radius, float force, uint color, int segments = 50)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + radius * GraphEditor.Zoom, cursorScreenPos.Y + radius);

        float outerRadius = radius + radius * force;
        ImGui.GetWindowDrawList().AddCircleFilled(center, outerRadius * GraphEditor.Zoom, color, segments);
    }

    public static void DrawNodeListArgInCircle(ArgIn argIn)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + 5, cursorScreenPos.Y + 5);
        ImGui.GetWindowDrawList().AddCircle(center, 5, ImGui.GetColorU32(ImGuiTheme.Colors.GetTypeColor(argIn.Type)));

        if (Helpers.IsMouseHoveringRadius(center, 5))
            Helpers.InOutTooltip(true, argIn.Type.Name);
    }

    public static void DrawNodeListArgOutCircle(ArgOut argOut)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + 5, cursorScreenPos.Y + 5);
        ImGui.GetWindowDrawList().AddCircle(center, 5, ImGui.GetColorU32(ImGuiTheme.Colors.GetTypeColor(argOut.Type)));

        if (Helpers.IsMouseHoveringRadius(center, 5))
            Helpers.InOutTooltip(true, argOut.Type.Name);
    }

    public static void DrawCursor(CursorType curType, Type type = null)
    {
        ImGui.SetMouseCursor(ImGuiMouseCursor.None);
        var mousePos = ImGui.GetIO().MousePos;

        switch (curType)
        {
            case CursorType.Default:
                var p1 = mousePos;
                var p2 = mousePos + new Vector2(12, 5) * 1.3f;
                var p3 = mousePos + new Vector2(5, 12) * 1.3f;
                ImGui.GetForegroundDrawList().AddTriangle(p1, p2, p3, ImGui.GetColorU32(ImGuiTheme.Colors.SelectedNodeColor));
                ImGui.GetForegroundDrawList().AddTriangleFilled(p1 + new Vector2(2, 2), p2 - new Vector2(3, 0), p3 - new Vector2(0, 3),
                    ImGui.GetColorU32(ImGuiTheme.Colors.White));
                break;

            case CursorType.InputOutput:
                ImGui.GetForegroundDrawList().AddCircleFilled(mousePos, 7, ImGui.GetColorU32(new Vector4(1, 1, 1, .8f)), 1);
                break;

            case CursorType.Argument:
                ImGui.GetForegroundDrawList().AddCircleFilled(mousePos, 7, ImGui.GetColorU32(ImGuiTheme.Colors.GetTypeColor(type)));
                break;
        }
    }
}
