<p align="center">
 <img src="https://i.imgur.com/PudKSwe.png" width="300" height="300" />
</p>

# BepInNode [![Github All Releases](https://img.shields.io/github/v/release/ImAxel0/BepInNode?&style=for-the-badge)]() [![Github All Releases](https://img.shields.io/github/downloads/ImAxel0/BepInNode/total.svg?&color=31CB15&style=for-the-badge)]()
**Node editor to make BepInEx plugins.**

| Release | IL2CPP | Mono |
| ------- | ------ | ---- |
| BIE 6.X | coming... | ✖️ |
| BIE 5.X | ✖️ | ✅ [link](https://github.com/ImAxel0/BepInNodeLoader_Mono) |

 ## Features :star:
 - **Shareable projects**: share you mod projects with others
 - **Runtime execution**: try node connections in realtime while in game
 - **Colored graph comments**: comment your node sections with what they do
 - **Node descriptions**: each node when hovered shows a description about what it does or how should be used
 - **Zoom**: zoomable graph editor
 - **Variables**: store values in containers to later use them
 - **Custom events**: alter the node flow and keeps a more tidy editor visual
 - **150+** available nodes exposed from the Unity API

## How it works 🛠️
Node connections are exported as `.nodemod` files (xml) and read back by a BepInEx mod (BepInNodeLoader) which executes them accordingly.

## Installation :arrow_down:
1. Download the latest **BepInNode.Setup.exe** from the [releases](https://github.com/ImAxel0/BepInNode/releases) section
2. Run the setup as administrator and install the application
3. Open the app and start making plugins

## Plugins installation :arrow_double_down:
1. Install [BepInNodeLoader](https://github.com/ImAxel0/BepInNodeLoader_Mono) as a standard BepInEx plugin
2. Place the `.nodemod` file in the `GameFolder/BepInEx/plugins/BepInNodeMods` folder
> BepInNodeMods folder will be created the first time BepInNodeLoader is run

## Requirements :warning:
- [.NET 6.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0#runtime-6.0.15)

![BepInNode screen](https://github.com/ImAxel0/BepInNode/assets/124681710/71f1ae05-c78f-4cbd-8a65-1eaeaa9dda20)

## Thanks to
- [BepInEx](https://github.com/BepInEx/BepInEx)
- [Dear ImGui](https://github.com/ocornut/imgui) & [ImGui.NET](https://github.com/ImGuiNET/ImGui.NET)
