using BepInNode.Nodes.Events;
using BepInNode.Nodes.GameObject;

namespace BepInNode.CustomAttributes
{
    public class CharsNoBlankTypes
    {
        /// <summary>
        /// List of node types where string input boxes can't have spaces
        /// </summary>
        public static List<Type> CharsNoBlank = new()
        {
            typeof(CustomEvent), typeof(GoGetComponent),
        };
    }
}
