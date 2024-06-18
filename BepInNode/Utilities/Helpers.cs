using BepInNode.Style;
using ImGuiNET;
using System.Numerics;
using System.Reflection;

namespace BepInNode.Utilities
{
    public class Helpers
    {
        public static void NodeTooltip(string description)
        {
            if (ImGui.IsItemHovered(ImGuiHoveredFlags.None))
            {
                ImGui.BeginTooltip();
                ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
                ImGui.TextUnformatted(description);
                ImGui.PopTextWrapPos();
                ImGui.EndTooltip();
            }
        }

        public static void NodeListTooltip(string nodeName, string description)
        {
            if (ImGui.IsItemHovered(ImGuiHoveredFlags.None))
            {
                ImGui.BeginTooltip();
                ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
                ImGui.TextColored(ImGuiTheme.Colors.Warning, nodeName);
                ImGui.TextUnformatted(description);
                ImGui.PopTextWrapPos();
                ImGui.EndTooltip();
            }
        }

        public static void InOutTooltip(bool onoff, string description)
        {
            if (onoff)
            {
                ImGui.BeginTooltip();
                ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
                ImGui.TextUnformatted(description);
                ImGui.PopTextWrapPos();
                ImGui.EndTooltip();
            }
        }

        public static bool IsMouseHoveringRadius(Vector2 center, float radius)
        {
            Vector2 mousePos = ImGui.GetMousePos();
            float distanceSquared = Vector2.DistanceSquared(mousePos, center);

            // Check if the distance squared is less than the radius squared
            return distanceSquared <= radius * radius;
        }

        public static bool ContainsType(List<Node> list, Type type)
        {
            return list.Any(x => x.GetType() == type);
        }

        public static bool TryGetEmbeddedResourceBytes(string name, out byte[] bytes)
        {
            bytes = null;

            var executingAssembly = Assembly.GetExecutingAssembly();

            var desiredManifestResources = executingAssembly.GetManifestResourceNames().FirstOrDefault(resourceName =>
            {
                var assemblyName = executingAssembly.GetName().Name;
                return !string.IsNullOrEmpty(assemblyName) && resourceName.StartsWith(assemblyName) && resourceName.Contains(name);
            });

            if (string.IsNullOrEmpty(desiredManifestResources))
                return false;

            using (var ms = new MemoryStream())
            {
                executingAssembly.GetManifestResourceStream(desiredManifestResources).CopyTo(ms);
                bytes = ms.ToArray();
                return true;
            }
        }
    }
}
