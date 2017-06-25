UnderworldExporter
==================
 
Welcome to Underworld Exporter -> Ultima Underworld 1 & 2 in Unity. 

Before you begin.

You will need a commercial release of either Ultima Underworld I&II in order to play. SS1 is also supported but is barebones.

Because I don't normally upload regular binary releases due to slow uploads the best (and most inconvenient) way to experience the game is to 
install Unity (5.4.1) and extract the workspace in the releases directory @ https://github.com/hankmorgan/UnderworldExporter/releases 
Then just extract the script files from the repository in order to get the most up to date code.

In this folder you will see files called uwdemo_path.txt, uw1_path.txt , uw2_path.txt and ss1_path.txt
Open each of these files and check that the file path in this file is pointing to the folder containing the matching game executable.
Make sure there is a trailing slash as in the file. eg c:\games\uw1\

Within the IDE change the properties of the GameObject called GameWorldContoller and change the RES parameter to one of UW0, UW1, UW2 or SS1.
THe default is UW1.

*If you own the gog.com versions you may need to extract the game files first. In the gog game folder find the file game.gog. Extract it using 7-zip or your file extractor of choice.

Controls
WASD - movement
Space - Jump
E - Toggle mouselook
Q - launch selected spell
F - Toggle fullscreen

UI elements are draggable in fullscreen. Note only a UW1 UI is enabled.

Asset Usage
A number of assets are currently loaded at runtime. These are mainly hud elements and fonts.

Gameplay Notes
There is no tuning of combat so don't expect it to be fun!
Most but not all spells are implemented. Consult your spellbook for rune combinations. Note that only UW1 magic is set up.
The game is theoretically beatable. Good luck.
Vanilla savegames are loadable and saveable. Savegames will overwrite vanilla save folders. Do so at your own risk.

Some known bugs
Limited range of resolutions.
The automap may hitch the first time you open it. Subsequent usage is okay.
Map notes may not scale in size with your resolution.
NavMesh generation is currently turned off. To enable just tick the EnableNavmesh generation in the GameWorldContoller
Animation effects are currently turned off.
UW2 is very buggy and not as feature complete as UW1.
The game now has a vanilla conversation virtual machine. This may act up.

Credits
This project would not be possible without the trailblazing work of Blue Sky Software (LookingGlass Studios) and the various teams that dug deep into the file formats of the Underworld and Shock games. Thanks. See the code credits.txt file for some specific examples where I took code from earlier projects.
