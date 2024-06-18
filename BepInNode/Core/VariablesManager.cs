using BepInNode.Core.CoreNodes.Variables.Get;
using BepInNode.Core.CoreNodes.Variables.Set;
using BepInNode.Graph;
using BepInNode.Style;
using BepInNode.Utilities;
using IconFonts;
using ImGuiNET;
using UnityEngine;
using Vanara.PInvoke;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace BepInNode.Core
{
    public class VariablesManager
    {
        public static string NameBuffer = string.Empty;
        public static Type SelectedType = typeof(int);

        public static List<string> VariablesId = new();
        public static Dictionary<string, Type> Variables = new();

        public static List<Type> VariableTypes = new()
        {
            typeof(int), 
            typeof(float), 
            typeof(bool),
            typeof(string), 
            typeof(Vector2),
            typeof(Vector3),
            typeof(UnityEngine.GameObject),
            typeof(UnityEngine.Component),
            typeof(UnityEngine.Rigidbody),
            typeof(UnityEngine.Transform),
            typeof(object)
        };

        public static void DeleteVariable(KeyValuePair<string, Type> variable, int idIndex)
        {
            var varNodes = GraphEditor.GraphNodes.Where(n => n.Id == VariablesId[idIndex]);
            foreach (var varNode in varNodes.ToList())
                NodesHandling.DeleteNode(varNode);

            VariablesId.RemoveAt(idIndex);
            Variables.Remove(variable.Key);
        }

        static void RenderTopInputs()
        {
            ImGui.BeginChild("VariablesTopBar", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 40));

            ImGui.Columns(3, string.Empty, false);

            ImGui.InputTextWithHint("Name", "...", ref NameBuffer, 1000, ImGuiInputTextFlags.CharsNoBlank);
            ImGui.NextColumn();
            if (ImGui.BeginCombo("Type", SelectedType.Name))
            {
                foreach (var varType in VariableTypes)
                {
                    if (ImGui.Selectable(varType.Name))
                        SelectedType = varType;
                }
                ImGui.EndCombo();
            }
            ImGui.NextColumn();
            if (ImGui.Button("Add", new(ImGui.GetContentRegionAvail().X, 25)))
            {
                if (string.IsNullOrEmpty(NameBuffer))
                {
                    User32.MessageBox(IntPtr.Zero, "Variable name field can't be empty", "Error creating variable",
                        User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
                    return;
                }

                if (!Variables.ContainsKey(NameBuffer))
                {
                    VariablesId.Add(Guid.NewGuid().ToString());
                    Variables.Add(NameBuffer, SelectedType);
                }
                else
                    User32.MessageBox(IntPtr.Zero, "Can't add a variable with the same name as another one", "Error",
                        User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
            }
            ImGui.Columns(1);

            ImGui.EndChild();
        }

        static void RenderVariables()
        {
            ImGui.BeginChild("VariablesList", ImGui.GetContentRegionAvail());

            int idx = 0;
            foreach (var variable in Variables.ToList())
            {
                ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new(0.13f, 0.13f, 0.13f, 1);
                ImGui.BeginChild(idx.ToString(), new(ImGui.GetContentRegionAvail().X, ImGui.CalcTextSize(variable.Key).Y * 2), ImGuiChildFlags.Border);

                ImGui.Columns(4, idx.ToString(), false);

                ImGui.TextColored(ImGuiTheme.Colors.GetTypeColor(variable.Value), variable.Key);
                Helpers.NodeTooltip(variable.Value.Name);
                ImGui.NextColumn();

                if (ImGui.Selectable("Get"))
                {
                    var newPos = new Vector2(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y) / GraphEditor.Zoom;
                    Node varNode = new();
                    switch (variable.Value)
                    {
                        case Type t when t == typeof(bool):
                            varNode = new BooleanGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"BoolGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(int):
                            varNode = new IntGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"IntGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(float):
                            varNode = new FloatGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"FloatGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(string):
                            varNode = new StringGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"StringGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Vector2):
                            varNode = new Vector2Get()
                            {
                                Id = VariablesId[idx],
                                Name = $"Vector2Get ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Vector3):
                            varNode = new Vector3Get()
                            {
                                Id = VariablesId[idx],
                                Name = $"Vector3Get ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(GameObject):
                            varNode = new GameObjectGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"GameObjectGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Component):
                            varNode = new ComponentGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"ComponentGet ({variable.Key})",
                                Position = newPos
                            };
                            break;


                        case Type t when t == typeof(Rigidbody):
                            varNode = new RigidbodyGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"RigidbodyGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Transform):
                            varNode = new TransformGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"TransformGet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(object):
                            varNode = new ObjectGet()
                            {
                                Id = VariablesId[idx],
                                Name = $"ObjectGet ({variable.Key})",
                                Position = newPos
                            };
                            break;
                    }
                    GraphEditor.GraphNodes.Add(varNode);
                }

                ImGui.NextColumn();

                if (ImGui.Selectable("Set"))
                {
                    var newPos = new Vector2(50 + GraphEditor.EditorScrollPos.X, 50 + GraphEditor.EditorScrollPos.Y) / GraphEditor.Zoom;
                    Node varNode = new();
                    switch (variable.Value)
                    {
                        case Type t when t == typeof(bool):
                            varNode = new BooleanSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"BoolSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(int):
                            varNode = new IntSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"IntSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(float):
                            varNode = new FloatSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"FloatSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(string):
                            varNode = new StringSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"StringSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Vector2):
                            varNode = new Vector2Set()
                            {
                                Id = VariablesId[idx],
                                Name = $"Vector2Set ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Vector3):
                            varNode = new Vector3Set()
                            {
                                Id = VariablesId[idx],
                                Name = $"Vector3Set ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(GameObject):
                            varNode = new GameObjectSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"GameObjectSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Component):
                            varNode = new ComponentSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"ComponentSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Rigidbody):
                            varNode = new RigidbodySet()
                            {
                                Id = VariablesId[idx],
                                Name = $"RigidbodySet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(Transform):
                            varNode = new TransformSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"TransformSet ({variable.Key})",
                                Position = newPos
                            };
                            break;

                        case Type t when t == typeof(object):
                            varNode = new ObjectSet()
                            {
                                Id = VariablesId[idx],
                                Name = $"ObjectSet ({variable.Key})",
                                Position = newPos
                            };
                            break;
                    }
                    GraphEditor.GraphNodes.Add(varNode);
                }

                ImGui.NextColumn();

                ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.Text] = ImGuiTheme.Colors.SelectedNodeColor;

                if (ImGui.Selectable("Delete", false, ImGuiSelectableFlags.AllowDoubleClick))
                {
                    if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        DeleteVariable(variable, idx);
                }
                ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.Text] = Vector4.One;

                ImGui.EndChild();
                idx++;
            }
            ImGui.EndChild();
        }

        public static void Render()
        {
            ImGuiTheme.LoggerTheme();

            ImGui.PushFont(FontController.GetFontOfSize(20));
            ImGui.SeparatorText($"Variables {FontAwesome6.SquareRootVariable}");
            ImGui.PopFont();
            Helpers.NodeTooltip("All variables must be SET atleast once before using the GET node");

            ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.2f, 0.22f, 0.23f, 1);
            ImGui.BeginChild("VariablesWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

            RenderTopInputs();
            ImGui.SeparatorText("##");
            RenderVariables();

            ImGui.EndChild();

            ImGuiTheme.ApplyTheme();

            HandleObjectVariablesOutput();
        }

        /// <summary>
        /// Converts output of object type variables to the corresponding attached input type
        /// To fix: attaching another input type to the SetNode converts the already converted output type causing a mismatch in types
        /// </summary>
        static void HandleObjectVariablesOutput()
        {
            var objectVariables = GraphEditor.GraphNodes.Where(n => n.GetType() == typeof(ObjectGet) || n.GetType() == typeof(ObjectSet));
            foreach (var node in objectVariables)
            {
                if (node.GetType() == typeof(ObjectGet))
                {
                    var setNodes = GraphEditor.GraphNodes.Where(x => x.Id == node.Id && x.GetType() == typeof(ObjectSet));

                    foreach (var setNode in setNodes)
                    {
                        if (setNode.ArgsIn[0].HasConnection)
                            node.ArgsOut[0].Type = setNode.ArgsOut[0].Type;
                    }
                }

                if (node.GetType() == typeof(ObjectSet) && node.ArgsIn[0].OutputArg != null)
                    node.ArgsOut[0].Type = node.ArgsIn[0].OutputArg.Type;
            }
        }
    }
}
