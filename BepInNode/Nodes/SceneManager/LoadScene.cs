using BepInNode.CustomAttributes;
using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace BepInNode.Nodes.SceneManager;

public class LoadScene : Node
{
    public string SceneName { get; set; }

    [IgnoreProperty]
    public LoadSceneMode EnumValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public List<Enum> SceneModeEnums { get; set; } = new();

    public LoadScene()
    {
        Name = nameof(LoadScene);
        Description = "Loads the Scene by its name";
        NodeCategory = NodeCategories.SceneManager;

        foreach (var key in Enum.GetValues(typeof(LoadSceneMode)))
            SceneModeEnums.Add((LoadSceneMode)key);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(LoadSceneMode), ArgName = nameof(LoadSceneMode) });
    }
}
