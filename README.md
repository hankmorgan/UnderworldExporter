UnderworldExporter
==================
            

Welcome to Underworld Exporter -> Ultima Underworld in Unity.

Before you begin.

You will need a commercial release of Ultima Underworld. Support for the demo version and basic UW2 support will happen in the future.

In this folder you will see a file called uw1_path.txt Check that the file path in this file is pointing to the folder containing the UW.EXE executable. Make sure their is a trailing slash as in the file. eg c:\games\uw1\

If you own the gog.com versions you may need to extract the game files first. In the gog game folder find the file game.gog. Extract it using 7-zip or your file extractor of choice.

Controls
WASD - movement
Space - Jump
E - Toggle mouselook
Q - launch selected spell
F - Toggle fullscreen

UI elements are draggable in fullscreen

Asset Usage
A number of assets are currently loaded at runtime. These are mainly hud elements and fonts.

Gameplay
Character generation is working but I recommend playing with the Quick Start option.
There is no tuning of combat so don't expect it to be fun!
Most but not all spells are implemented. Consult your spellbook for rune combinations.
The game is theoretically beatable. Good luck.

Some known bugs
Limited range of resolutions.
Save and load is not working
After you close the automap the context ui won't update until you hover over another object
The automap may hitch the first time you open it. Subsequent usage is okay.
Map notes may not scale in size with your resolution.
AI's may walk across water to get to you.
Water monsters float off the ground.
Animation effects are currently turned off.
Some conversations may act up. Especially when dealing with items. If in doubt kill the NPC and take what you need!

I've recently overhauled asset loading and animation handling. There may be dragons here so play at your own risk.

Credits

This project would not be possible without the trailblazing work of Blue Sky Software (LookingGlass Studios) and the various teams that dug deep into the file formats of the Underworld and Shock games. Thanks. See the code credits.txt file for some specific examples where I took code from earlier projects.
