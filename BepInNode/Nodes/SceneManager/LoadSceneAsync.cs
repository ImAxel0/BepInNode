using BepInNode.CustomAttributes;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace BepInNode.Nodes.SceneManager;

public class LoadSceneAsync : Node
{
    public string SceneName { get; set; }

    [IgnoreProperty]
    public LoadSceneMode EnumValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public List<Enum> SceneModeEnums { get; set; } = new();

    public LoadSceneAsync()
    {
        Name = nameof(LoadSceneAsync);
        Description = "Loads the Scene asynchronously in the background.";
        NodeCategory = NodeCategories.SceneManager;

        foreach (var key in Enum.GetValues(typeof(LoadSceneMode)))
            SceneModeEnums.Add((LoadSceneMode)key);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(LoadSceneMode), ArgName = nameof(LoadSceneMode) });
    }
}
