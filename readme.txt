UnderworldExporter
==================
 
Welcome to Underworld Exporter (UWE) -> Ultima Underworld 1 & 2 in Unity. 

Release 1.03


Contents
	1 - Game Support
	2 - Installation and Configuration
	3 - Controls 
	4 - Gameplay
	5 - In-game editor
	6 - Known issues and bugs
	7 - Credits and acknowledgements

1 Games Supported

	The following Looking Glass Studios games are supported to various levels. Original game files are absolutley required to play however in the interests of full disclosure some UI assets and sound effects are bundled with this download.

	1.1 Ultima Underworld 1 (UW1).
		UW1 is fully supported and can be completed from start to finish. Save games are both forward and backwardly compatable with the original dos version.

	1.2 Ultima Undeworld 1 Demo Version (UW0)
		UW0 is a freely available demo of the first level of UW1. It is fully supported with the following exceptions:
			-The rolling demo is not supported.
			-Weapon animations are not currently working (combat still works)

	1.3 Ultima Underworld 2 (UW2)
		UW2 is partially supported with full support to come in time.
			-Game saves (loading of vanilla saves is possible)
			-Some traps and triggers are not implemented.
			-Many new conversation functions are not implemented
			-UW2 specific HUD is not implemented.		
			
	1.4 System Shock 1 (SHOCK)
		SHOCK is currently enabled in a map viewer mode. Developement of any SS1 focused releases has been postponed pending completion of Underworld 1&2.
		
	1.4 Terra Nove Strike Force Centrauri (TNOVA)
		TNOVA is implemented as a side project map-viewer. There are no plans to develop this game any further.	
		
2 Installation and Configuration
	The same executable is used for all games. 
	Download the uwe.zip file and extract it to any location you wish. (eg c:\games\uwe\)
	In the extracted folder open the config.ini file. 

	For each game there is a different config variable for the game paths.  EG  Path_UW1 for Underworld 1. Edit the file path to match the folder where the original game is located.
		Eg If the UW1 executable uw.exe is at c:\games\uw1\uw.exe then you should enter c:\games\uw1\ in the path file next to Path_UW1
	Launch the exporter by running the uwe.exe executable.
	When you launch the splash screen should detail the games found and the paths recorded for them. 
	Click on a game icon to launch.
		UW1 and UW2 will take you to the main menu.
		UW0 will take you straight to the game world.
		For SHOCK and TNOVA you can select a level to load from the drop down boxes.
	
	*If you own the gog.com versions you may need to extract the game files first. In the gog game folder find the file game.gog. Extract it using 7-zip or your file extractor of choice and point your paths to this extracted data.	

3  The following are the default controls

	Movement - WASD
	Jump - Spare
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
		
	4.4 Conversations and items
		Vanilla behavior in conversations is for objects to move to the players cursor when given by an npc. As implemented objects will immediately spawn at the top level of the players inventory. If there is no space they will spawn at the npcs position.

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
	Animated textures use a special shader that cycles the game palette. Currently this shader does not support lighting and animated textures will appear full bright.
	Npcs in combat do not turn to face you quickly. NPC AI in general is not great at combat so try and play fair with them.
	UW2 is very buggy and not as feature complete as UW1.
	No weapon animations in UW0. Animations in UW2 are misaligned.
	Occasional glitches may occur when loading save games produced by UWE in vanilla underworld.
	Pushing against NPCs may allow you to walk over them.	
	Sound design is very basic at the moment. Sound effects are from Underworld 2.

7 Credits
	This project would not be possible without the trailblazing work of Blue Sky Software (LookingGlass Studios) and the various teams that dug deep into the file formats of the Underworld and Shock games. Thanks. See the code credits.txt file for some specific examples where I took code from earlier projects.
