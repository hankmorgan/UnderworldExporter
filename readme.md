## January 2024 Status Update
* Primary focus areas are on Reverse Engineering of UW2 and I have moved code development away from Unity to Godot to ensure the engine and software is more fully open source as well as avoiding risks due to Unity licencing changes. The repository of the Godot version will be made public this Spring. Obviously this version is currently less functiontal but will have benefited for the work on reverse engineering and hopefully be a better vanilla+ experience for Underworld.

### Godot Version Features
Current implemented features in the Godot Version
* Level Geometry and textures
* Paperdoll, runebag, stats display and health displays.
* Object use and look interactions including door locks, signs and food consumption
* Several traps/triggers
* NPC and Object sprites loading
* Basic conversation logic
* Vanilla light shading effect
* Palette cycling effects
* Supports UW1 and UW2 levels and save files.
* Better access to object, player and tile data structures.

Currently working on.
* Smoothing out conversations for Level 1 of UW1 as part of a vertical slice.

Code will be in C# and where possible Unity implementations of features will be migrated and updated.

>>  As such no future updates or supports is planned for this Unity version.

## July 2023 Status Update
* Current project focus has been on reverse engineering and additions to the editor . I'm hoping to swtich to feature implementation soon but time is limited. Bug fixes may be infrequent as I just want to get features added to UW2 before focusing on polish.

* https://github.com/hankmorgan/Underworld-Editor
* https://github.com/hankmorgan/UWReverseEngineering

> Please note I think the best way to play UW is still the Gog.com release of the game in dosbox. If you are looking to get into UW for the first time then start there.


## Jan 2023 Status Update
* After an extended break I have resumed work on Underworld. Main focus is on reverse engineering of the UW2 executable (https://github.com/hankmorgan/UWReverseEngineering) so don't expect anything playable for the forseeable until I have completed work there.
* Good progress has been made on reverse engineering

* If you want something vaguely playable the most recent playable material is the repo for the Unity Scene files (https://github.com/hankmorgan/Underworld-Exporter-Scene). Require the Unity Dev environment to play.

Thanks for your patience!


# UnderworldExporter
==================
 
Welcome to Underworld Exporter (UWE) -> Ultima Underworld 1 & 2 in Unity. 

> Release 1.09


Contents
	0 - Notes on this release
	1 - Game Support
	2 - Installation and Configuration
	3 - Controls 
	4 - Gameplay
	5 - In-game editor
	6 - Known issues and bugs
	7 - Credits and acknowledgements

0 - Notes on this release
	-This is a maintenance and bugfix update to release 1.08. 
	-New features/changes 
		- Automatic door key Usage (enabled in config.ini)
		- Clickable conversation options
		- Restoration of loading of modded textures.
		- In game editor disabled in this release due to interface bugs. WIll likely phase this out in favour of the standalone Underworld Editor that is WIP.

1 Games Supported

	The following Looking Glass Studios games are supported to various levels. Original game files are required to play however in the interests of full disclosure some UI assets and sound effects are bundled with this download.

	1.1 Ultima Underworld 1 (UW1).
		UW1 is fully supported and can be completed from start to finish. Save games are both forward and backwardly compatable with the original dos version.

	1.2 Ultima Underworld 1 Demo Version (UW0)
		UW0 is a freely available demo of the first level of UW1. It is fully supported with the following exceptions:
			-The rolling demo is not supported.
			-Weapon animations are not currently working (combat still works)

	1.3 Ultima Underworld 2 (UW2)
		UW2 is partially supported with fuller support to come in time.
			
	1.4 System Shock 1 (SHOCK)
		SHOCK is currently enabled in a map viewer mode. Developement of any SS1 focused releases has been postponed pending completion of Underworld 1&2.
		
	1.4 Terra Nove Strike Force Centauri (TNOVA)
		TNOVA is implemented as a side project map-viewer. There are no plans to develop this game any further.	
		
2 Installation and Configuration

	2.1 Setup
		The same executable is used for all games. 
		
		Download the zip file and extract it to any location you wish.
		
		In the extracted folder open the config.ini file. 
	
		For each game there is a different config variable for the game paths.  EG  Path_UW1 for Underworld 1. Edit the file path to match the folder where the original game is located.
		Eg If the UW1 executable uw.exe is at c:\games\uw1\uw.exe then you should enter c:\games\uw1\ in the path file next to Path_UW1
		
		Launch the exporter by running the uwe.exe executable.
	
		When you launch the splash screen should detail the games found and the paths recorded for them. 
	
		Click on a game icon to launch.
			UW1 and UW2 will take you to the main menu.
			UW0 will take you straight to the game world.
			For SHOCK and TNOVA you can select a level to load from the drop down boxes.
	
	*If you own the gog.com versions you may need to extract the game files first. In the gog game folder find the file game.gog. Extract it using 7-zip or your file extractor of choice and point your paths to the game folders within this extracted data.	

	2.2 Soundtrack
		In release 1.05 the music files have been put into an external folder. This allows the use of custom soundtracks. A number of prebuilt sound tracks have been uploaded and these are
	- The PSX release of the soundtrack
	- An Sound blaster style soundtrack
	- A midi soundtrack.

To enable a sound track open config.ini and find the UW1_Soundbank setting. Enter the path to the folder containing the music.

The music files must be in .ogg format and named 01.ogg to 15.ogg  Refer to the SB16 soundtrack for exact files to use.


3  The following are the default controls

	Movement - WASD
	Jump - Space
	Toggle mouselook* - E
	Cast selected spell* - Q
	Toggle fullscreen* - F  (some ui elements are draggable in fullscreen mode)
	Interaction modes*  F1 to F6.
	Fly Up* - R
	Fly down* = V
	Track* = T
	Charge Attack - Hold down right mouse key
	Release Attack - Release right mouse key.

	In game a context sensitive overlay will tell you what a right or left click will do when hovering over an object.

	*These controls can be edited by changing the values in the config.ini file. Other standard controls are managed by the Unity launcher. Mouse sensitivity and axis settings can be configured from the config.ini

4 Gameplay

	4.1 Getting Started with UW1
		When you load up UW1 you will be at the main menu. There are 6 options here Introduction, Create Character, Journey Onwards, Acknowledgements, SpeedStart and Enable Editor.
		Select Create Character if you want to play the game properly. Select Journey onwards if you want to load a save game, Speedstart will immediately launch you into the game with a cheat character that has full stats, runestones and 255 health and mana.
		When you arrive in the underworld you will be in the inventory interaction mode. Pressing E will allow you to toggle between interaction and mouse look modes.
		You will see a bag in front of you. Enter interaction mode or aim at it in inventory mode and right click on it to pick it up.
		Drag the bag onto one of your inventory slots and left click to place.
		In the inventory left click on the bag to open. You will see the following items
			Dagger - Drag this onto the left or right hand slot on the paperdoll. The handedness you selected in character generation controls which is the correct hand to use.
			Torch - Click on the torch and it will light up in a free slot.
			Map - Click on this to get your location. Clicking anywhere on the map allows you to add map notes.
		Clicking the icon of the opened bag allows you to close the container.
		Look around you. You will see a sign on the wall. Switch to look mode (Eyeball button) to read it.
		Move down the hall. Take a left, another left and follow the path until you see two runestones (Ort and Jux) on the ground. Pick these up.
		Go Right and in the corner of the next room you will see a backpack. Pick it up and open it.
		In the bag you will see a rune bag. Drag the rune bag to a free slot on your paperdoll.
		Drag and drop all the rune stones you have onto the runebag and the will be added to your available runes. Open the runebag to see what you have.
		If you created a character with magic skills you can try and cast a spell now
		Select the Runes Ort and Jux (in that order). Right clicking the runes will tell you what each one is. The runes will appear on the shelf next to the compass.
		Either click on the shelf or press Q to cast the spell.
		This spell is Magic Arrow and will change your cursor into a ring. Aim with the mouse and when you are ready to fire right click to launch the magic spell.
		In the Bagpack you will also see a key. Left click on it and your cursor will change to match the key. Move to the door and left click on it. This will unlock the door.
		Move through the door and up to the next room. In the next room you will see an outcast.
		Left click on the outcast to talk to them. In conversations use the number keys to select your answers.
		WHen you have finished the conversation turn around and in the corner of the room you will see a bedroll. Take it with you.
		Move on to the next room and follow the slope down to your left.
		Pressing space at the game will allow you to jump over the small gap.
		On the island across the stream you will see a hostile rotworm. 
		Cross over the water and draw your weapon by either left clicking on your weapon, pressing F5 or clicking the sword icon on the left.
		Charge your attack by holding down the right mouse key. Point the mouse cursor at the worm and release the attack by lifting the key. Repeat until the worm is dead.
		Put your weapon away by clicking on the sword and look at the wall. You will see a switch.
		Click on it and the nearby door will open granting you some more access to the level. You can also go back to where you started and take another path. The choice is yours.

		Tips:
			Looking at walls using the "Look" interaction mode is required to find some secrets.
			The silver tree is found on the first level and will resurrect you when you die if you replant it.
			Things will be easier for you if you find the ring of leviation or ring of leap.			
	
	4.2 Combat Mechanics
		The following is how combat is implemented based on my understanding of the skill systems as described in this article http://wiki.ultimacodex.com/wiki/Skill_System_of_Underworld_I_and_II
		NPCs have an attack and defence score defined by their object properties.
		The player has an attack score which is their attack skill plus half their current weapon skill 
		The player has a defence score which is their defence skill plus half their current weapon skill 
		
		The defenders defense score and the attacks attack score are calculated to give a ToHit score. (defence-attack) = toHit. This score is never less than 0 or greater than 29. A random dice roll of 1-30 is taken and this determines if the hit is sucessful.
		
		If a hit is scored the damage is taken off the defender.
		If the attacker is a player then the damage is the weapon swing type damage score by the percentage attack charge built up.
		If the attack is an NPC then the damage is a random 1 to max damage score.
		
		Npcs have an equipment damage score. This less the players total armour score is applied as a single point of damage to a random piece of armour.
			
		Spell, Weapon and armour enchantments and scores can further change these values.
			Protection enchantments increase defence
			Accuracy enchantments increase attack score
			Toughness enchantments reduce damage.
			Durability enchantments reduce equipment damage sustained
				
	4.3 Trading
		Trading with NPCs is not currently calculating a value to the items traded. To make a trade with an npc just offer any item and and keep trying until they accept.	


5 In Game Editor
	An ingame editor is bundled for experimentation. The following can be achieved with this
		-Edit maps
		-Edit objects and NPCs
		-Change texture maps		
		
	Usage:
		At the main menu of UW1/UW2 click the enable Editor button. Starting a new game, save game or quick starting will bring you into the editor
		Additional controls
			Top Right Eyeball. - Toggles Editor Panel
			Load button - Will load the level number entered in the box.
			The buttons next to the map will switch special modes, change player position etc.
			
			Tile View : Allows changing of tile properties.				
				Up and down Arrows allow browsing of tiles by co-ordinate. 
				The teleport buttons next to the overhead map will either move the player to the selected tile or select the tile the player is on.
				Use the first drop down to change the tile type.
				Tile Height will change the floor level.
				Floor and Wall textures can be changed from the drop down.
				A range of tiles can also be changed by entering values. These values can be positive or negative and are relative to the selected tiles (zero-based). The type of tile selected has different behaviours when this option is used.	A value of 0x0 just changes the current tile.
				The Lock Toggles can be used to control what properties can change when updating a range of tiles. For instance if you only want to change the floor textures of the tiles you will tick all boxes except the floor box.
				Follow-Me Mode. Pressing the Paint brush enables Follow me mode. This takes the properties of the tile you have selected and as you move around the level it will "paint" other tiles with those properties. The lock toggles can be used here as well. 
				The Use Key. The standard ingame use key behaves differently in the editor. Normally it will select a tile you click on with it. If you are in Follow-Me mode it will change that tile for you.
				
			Object View : Allows editing of object properties
				From the drop down select an object to edit. 1024 object slots are available in game. Not all slots are in use and have objects generated in the game world. Objects that are not in use will normally have an tile X and tile Y of 99. Note that container contents and special objects may also be at this location. Setting an objects tile X and tile Y to a value between 0 and 63 will create the object in the gameworld.
				If you want to edit containers it is recommended that you do so from within the normal game inventory screens.
				Changes to the next value will normally be ignored as this is a value that is normally managed by the game engine. The only exception to this is for the use trigger and the Lock object which use the next value for special purposes.
				If the object is a mobile object (NPC or magic projectile) an additional panel with properties will appear.
				
			Texture Map Editor: Allows changing of the level wall, floor and door texture palette 
				Clicking on the this option brings up a display of all textures in the map. Clicking on a texture selects it. The selected texture can then be changed from the drop down.

6 Some known bugs and issues
	Limited range of resolutions due to using original game art.
	3D models have placeholder texturing.
	Map notes may not scale in size with your resolution.
	UW2 is very buggy and not as feature complete as UW1.
	No weapon animations in UW0. Animations in UW2 are misaligned.
	Occasional glitches may occur when loading save games produced by UWE in vanilla underworld.
	Pushing against NPCs may allow you to walk over them.	
	Sound design is very basic at the moment. Sound effects are from Underworld 2.
	The Terra Nova make viewer sometimes fails to render tiles. This appears to be due to the shear volume of tiles rendered. 512x512 tiles in total.

7 Credits
	This project would not be possible without the trailblazing work of Blue Sky Software (LookingGlass Studios) and the various teams that dug deep into the file formats of the Underworld and Shock games. Thanks. See the code credits.txt file for some specific examples where I took code from earlier projects.
