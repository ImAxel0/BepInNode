using ImGuiNET;

namespace BepInNode.Utilities
{
    public class FontController
    {
        public static List<ImFontPtr> Fonts = new();

        public static ImFontPtr GetFontOfSize(int size)
        {
            int s = System.Math.Clamp(size, 16, 100);
            return Fonts[s - 16];
        }
    }
}
