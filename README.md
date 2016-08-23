UnderworldExporter
==================

Toolset for converting Ultima Underworld and System Shock 1 levels and objects into other engines. Primarily Unity but earlier versions supported Idtech 4, Source Engine. Most features are geared towards UW1. UW2&SS1 are in cryosleep at the moment but the basic process works for them.

Demo:
http://www.mediafire.com/download/qde3ragktd91k3r/UW1_20160823.zip

Unity 5 workspace
http://www.mediafire.com/download/l2xsy09b7q3xnxd/uw1_dev_environment.zip


Basic jist of what this does for creating in Unity.

Exports a map into a .fbx model.
Extracts the textures in specific order and naming
Extracts the game strings
Extracts the object and interface art.
Extracts the creature animation art and generates a script to make animation assets for them. Similarly for weapons
Extracts a big old editor script that re-creates the individual game objects to a T.

Attached UnityScripts for implementing vanilla game behaviour.

The tool is also a general purpose extractor, decompressor and data dumper.
