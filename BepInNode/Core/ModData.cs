namespace BepInNode.Core;

public class ModData
{
    public string AppVersion { get; set; }
    public string ModName { get; set; }
    public string ModAuthor { get; set; }
    public string ModVersion { get; set; }
    public List<Node> OnLoad { get; set; }
    public List<Node> Update { get; set; }
    public List<Node> FixedUpdate { get; set; }
    public List<Node> CustomEvents { get; set; }
}
