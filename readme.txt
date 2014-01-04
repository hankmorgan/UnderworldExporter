Underworld (and now System Shock as well) Exporter.


Acknowledgements

-Please see code credits.txt for specific credits on various previous Underworld/Shock projects that I have taken some code from.

-Special word of thanks to the various authors of uw-formats.txt and ss-specs.txt without whom this would not be possible.


Features
-Export Ultima Underworld 1,2, Underworld demo and System Shock(partial support currently) maps into Doom3(untested but should work with broken textures)/Darkmod .map files
-Export Ultima Underworld 1,2, Underworld demo and System Shock(partial support currently), maps into ascii tile maps.
-Extract Underworld bitmap textures from w64.tr
-Extract Underworld 1/2/demo(?) strings from strings.dat
-Build script files for Underworld 1.
-Level transitions between levels (assuming levels follow a naming convention) uw1_x.map. There is no persistance at the moment.

Usage.

A lot of stuff is hard coded at the moment. Future releases will be more friendly and less hacky in this regard. If you want to change the paths to your own game files just look for the file paths in main.h.

You can configure texture replacements/ objects using the config files.


1. Making maps
Make sure the file paths are pointed to the correct game files
Compile and in a console pipe the output to a file. eg underworldexporter.exe > mymapname.map
You will still need to add your player start and add lights to the map in Radiant.

2. Extracting stuff.
Just uncomment out the function calls in main.cpp to try these out. Strings are piped to the console at the moment and textures will be exported as bit maps. It's possible also to export specific byt(eg main interface) files by changing the path to the .byt file, forcing the NoOfTextures variable to 0 before the loop and specifying height and width = 64.

3. Script building. Run the tool in ASCII mode (Change D3MODE to ASCIIMODE) and take the script chains section from that ascii dump and paste it's contents in the build materials/script chains.txt. This will create scripts for a number of things including terrain traps, elevators, enchantment debugging, interactable items that trigger traps (including "text traps) using the vb prototype program.
 

Some known Issues.
-A lot of objects are place holders.
-UW object origin is different from darkmod origin so there may be some weirdmisalignments.