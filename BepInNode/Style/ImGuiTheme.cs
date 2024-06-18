using ImGuiNET;
using System.Numerics;

namespace BepInNode.Style;

public class ImGuiTheme
{
    public static ImGuiStylePtr ImGuiStyle;

    static float _windowRounding = 0;
    static float _childRounding = 0;
    static float _frameRounding = 2;
    static float _frameBorder = 0;
    static Vector4 _textColor = new(0.9f, 0.9f, 0.9f, 1);
    static Vector4 _childBgColor = new(0.15f, 0.15f, 0.16f, 1);
    static Vector4 _headersColor = new(0.15f, 0.15f, 0.16f, 1);
    static Vector4 _frameColor = new(0.10f, 0.10f, 0.10f, 1);
    static Vector4 _borderColor = new(0.2f, 0.2f, 0.2f, 1);

    public static class Colors
    {
        public static Vector4 White = new(1, 1, 1, 1);
        public static Vector4 Warning = new(1.00f, 0.76f, 0.30f, 1);
        public static Vector4 Error = new(0.96f, 0.38f, 0.42f, 1);
        public static Vector4 SelectedNodeColor = new(1, 0, 0.28f, 0.8f);
        public static Vector4 Brown = new(0.45f, 0.27f, 0.21f, 1);

        public static Vector4 GetTypeColor(Type type)
        {
            switch (type)
            {
                case Type t when t == typeof(bool):
                    return new Vector4(1, 0, 0, 1);

                case Type t when t == typeof(int):
                    return new Vector4(0.11f, 0.90f, 0.69f, 1);

                case Type t when t == typeof(float):
                    return new Vector4(0.66f, 1.00f, 0.31f, 1);

                case Type t when t == typeof(string):
                    return new Vector4(0.98f, 0.00f, 0.82f, 1);

                case Type t when t == typeof(Vector3) || t == typeof(Vector2):
                    return new Vector4(0.99f, 0.78f, 0.13f, 1);

                case Type t when t == typeof(UnityEngine.Transform):
                    return new Vector4(0.36f, 0.30f, 0.77f, 1);

                case Type t when t == typeof(UnityEngine.GameObject):
                    return new Vector4(0.75f, 0.47f, 0.77f, 1);

                case Type t when t == typeof(UnityEngine.Component):
                    return new Vector4(0.20f, 0.32f, 0.94f, 1);

                case Type t when t == typeof(UnityEngine.Rigidbody):
                    return new Vector4(1.00f, 0.87f, 0.57f, 1);
            }
            return new Vector4(0.00f, 0.66f, 0.95f, 1);
        }
    }

    public static void ApplyTheme()
    {
        ImGuiStyle.WindowRounding = _windowRounding;
        ImGuiStyle.ChildRounding = _childRounding;
        ImGuiStyle.FrameRounding = _frameRounding;
        ImGuiStyle.FrameBorderSize = _frameBorder;
        ImGuiStyle.ScrollbarRounding = _frameBorder;
        //ImGuiStyle.Colors[(int)ImGuiCol.MenuBarBg] = _menuBarBgColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Text] = _textColor;
        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = _childBgColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Border] = _borderColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = _frameColor * 2;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = _frameColor;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = _frameColor;
        ImGuiStyle.Colors[(int)ImGuiCol.SeparatorHovered] = Colors.SelectedNodeColor;
        ImGuiStyle.Colors[(int)ImGuiCol.SeparatorActive] = Colors.SelectedNodeColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Button] = Colors.Brown;
        ImGuiStyle.Colors[(int)ImGuiCol.ButtonHovered] = Colors.Brown * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.ButtonActive] = Colors.Brown;
        ImGuiStyle.Colors[(int)ImGuiCol.TitleBg] = _childBgColor;
        ImGuiStyle.Colors[(int)ImGuiCol.TitleBgActive] = _childBgColor;
    }

    public static void EditorTheme()
    {
        ImGuiStyle.ChildRounding = _childRounding;
        ImGuiStyle.FrameRounding = _frameRounding;
        ImGuiStyle.FrameBorderSize = _frameBorder;
        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new(0.13f, 0.13f, 0.13f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = Colors.Brown * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = Colors.Brown;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = Colors.Brown;
    }

    public static void CommentTheme()
    {
        ImGuiStyle.ChildRounding = 5;
        ImGuiStyle.FrameRounding = 5;
        ImGuiStyle.FrameBorderSize = 0;
    }

    public static void NodeTheme(Node node)
    {
        ImGuiStyle.ChildRounding = 5;
        ImGuiStyle.FrameRounding = 5;
        ImGuiStyle.FrameBorderSize = 1;

        Vector4 col;
        switch (node.NodeType)
        {
            case Node.NodeTypes.Starter:
                col = new Vector4(Colors.Brown.X, Colors.Brown.Y, Colors.Brown.Z, 1) * 0.8f;
                break;
            case Node.NodeTypes.Variable:
                col = Colors.GetTypeColor(node.ArgsOut[0].Type);
                col = new(col.X, col.Y, col.Z, .2f);
                break;
            default:
                col = new(0.20f, 0.20f, 0.21f, .8f);
                break;
        }

        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = col;
        ImGuiStyle.Colors[(int)ImGuiCol.Border] = new Vector4(0, 0, 0, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.16f, 0.16f, 0.16f, 1) * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = new(0.16f, 0.16f, 0.16f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = new(0.16f, 0.16f, 0.16f, 1);
    }

    public static void LoggerTheme()
    {
        ImGuiStyle.ChildRounding = _childRounding;
        ImGuiStyle.FrameRounding = _frameRounding;
        ImGuiStyle.FrameBorderSize = _frameBorder;
        ImGuiStyle.Colors[(int)ImGuiCol.Border] = _borderColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = _frameColor * 2;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = _frameColor;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = _frameColor;
    }
}
