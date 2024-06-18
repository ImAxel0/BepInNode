using BepInNode.Core.Project;
using BepInNode.Graph;
using BepInNode.Style;
using BepInNode.Utilities;
using ImGuiNET;
using System.Diagnostics;
using System.Numerics;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace BepInNode.Core
{
    internal class Program
    {
        public static Sdl2Window _window;
        public static GraphicsDevice _gd;
        public static CommandList _cl;
        public static ImGuiController _controller;
        private static Vector3 _clearColor = new(0.45f, 0.55f, 0.6f);
        private static string _windowTitle = "BepInNode";

        static void Main(string[] args)
        {
            VeldridStartup.CreateWindowAndGraphicsDevice(
                new WindowCreateInfo(50, 50, 1280, 720, WindowState.Maximized, $"{_windowTitle} {ProgramData.AppVersion}"),
                new GraphicsDeviceOptions(false, null, true, ResourceBindingModel.Improved, true, true),
                out _window,
                out _gd);
            _window.Resized += () =>
            {
                _gd.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
                _controller.WindowResized(_window.Width, _window.Height);
            };
            _cl = _gd.ResourceFactory.CreateCommandList();
            _controller = new ImGuiController(_gd, _gd.MainSwapchain.Framebuffer.OutputDescription, _window.Width, _window.Height);

            var stopwatch = Stopwatch.StartNew();
            float deltaTime = 0f;

            ProgramData.InitializeProgram();
            ImGuiTheme.ImGuiStyle = ImGui.GetStyle();
            ImGuiTheme.ApplyTheme();

            while (_window.Exists)
            {
                deltaTime = stopwatch.ElapsedTicks / (float)Stopwatch.Frequency;
                stopwatch.Restart();
                InputSnapshot snapshot = _window.PumpEvents();
                if (!_window.Exists) { break; }
                _controller.Update(deltaTime, snapshot);

                if (_window.WindowState == WindowState.Minimized)
                {
                    Thread.Sleep(100);
                    continue;
                }

                ShortcutHelper.ListenForShortcuts();
                if (ImGui.IsKeyPressed(ImGuiKey.F11, false))
                {
                    var windowsState = _window.WindowState == WindowState.BorderlessFullScreen ? WindowState.Normal : WindowState.BorderlessFullScreen;
                    _window.WindowState = windowsState;
                }

                RenderUI();

                ImGuiController.UpdateMouseCursor();

                _cl.Begin();
                _cl.SetFramebuffer(_gd.MainSwapchain.Framebuffer);
                _cl.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 1f));
                _controller.Render(_gd, _cl);
                _cl.End();
                _gd.SubmitCommands(_cl);
                _gd.SwapBuffers(_gd.MainSwapchain);
            }

            ProgramSettings.SaveSettings();

            _gd.WaitForIdle();
            _controller.Dispose();
            _cl.Dispose();
            _gd.Dispose();
        }

        static void RenderUI()
        {
            ImGui.SetNextWindowPos(Vector2.Zero);
            ImGui.SetNextWindowSize(ImGui.GetIO().DisplaySize);
            ImGui.Begin("MainWindow", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse
                | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.MenuBar);

            AboutDialog.Render();
            ProjectDialogBuild.Render();
            MenuBar.Render();
            NodeList.Render();
            ImGui.SameLine();
            GraphEditor.Render();

            ImGui.End();
        }
    }
}