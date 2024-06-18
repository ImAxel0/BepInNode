using BepInNode.Utilities;
using System.Reflection;
using System.Xml.Serialization;
using Vanara.PInvoke;

namespace BepInNode.Core.Project;

public class ProjectSerializer
{
    public static void SerializeModData(string path, ModData modData)
    {
        string modPath = path;

        try
        {
            using (FileStream fileStream = new FileStream(modPath, FileMode.Create))
            {
                var derived = GetDerivedTypes(typeof(Node));
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ModData), derived);
                xmlSerializer.Serialize(fileStream, modData);
            }
            Logger.Append($"Mod built successfully at {modPath}");
            User32.MessageBox(IntPtr.Zero, $"Mod built successfully at {modPath}", "Build result", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_TOPMOST);
        }
        catch (Exception ex)
        {
            Logger.Append($"{ex.Message}");
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Build result", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
        }

        ProjectBuilder.CleanForNextBuild();
    }

    public static string SerializeModDataAsString(ModData modData)
    {
        var derived = GetDerivedTypes(typeof(Node));
        XmlSerializer xmlSerializer = new(typeof(ModData), derived);
        StringWriter stringWriter = new();
        xmlSerializer.Serialize(stringWriter, modData);
        ProjectBuilder.CleanForNextBuild();
        return stringWriter.ToString();
    }

    private static Type[] GetDerivedTypes(Type baseType)
    {
        List<Type> derivedTypes = new();
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            if (baseType.IsAssignableFrom(type) && type != baseType)
                derivedTypes.Add(type);
        }
        return derivedTypes.ToArray();
    }
}
