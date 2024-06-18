using BepInNode.Graph;
using Newtonsoft.Json;
using Syroot.Windows.IO;
using Vanara.PInvoke;

namespace BepInNode.Core;

public class ProgramSettings
{
    private static string _settingsPath = Path.Combine(KnownFolders.RoamingAppData.Path, "BepInNode", "Settings.json");

    private class SettingsData
    {
        public float GridSize;
        public float PanSpeed;
        public bool HideNodeListArguments;
    }

    public static void LoadSettings()
    {
        JsonSerializerSettings settings = new()
        {
            Formatting = Formatting.Indented,
        };

        if (File.Exists(_settingsPath))
        {
            string json = File.ReadAllText(_settingsPath);

            try
            {
                var storedSettings = JsonConvert.DeserializeObject<SettingsData>(json, settings);
                GraphEditor.GridSize = storedSettings.GridSize;
                GraphEditor.PanSpeed = storedSettings.PanSpeed;
                NodeList.HideArguments = storedSettings.HideNodeListArguments;
            }
            catch (Exception ex)
            {
                User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error loading program settings", 
                    User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
            }
        }
    }

    public static void SaveSettings()
    {
        JsonSerializerSettings settings = new()
        {
            Formatting = Formatting.Indented,
        };

        var data = new SettingsData()
        {
            GridSize = GraphEditor.GridSize,
            PanSpeed = GraphEditor.PanSpeed,
            HideNodeListArguments = NodeList.HideArguments,
        };

        string json = JsonConvert.SerializeObject(data, settings);

        try
        {
            Directory.CreateDirectory(Path.Combine(KnownFolders.RoamingAppData.Path, "BepInNode"));
            File.WriteAllText(_settingsPath, json);
        }
        catch (Exception ex)
        {
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error saving program settings", 
                User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
        }
    }
}
