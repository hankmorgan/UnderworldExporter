UnderworldExporter
==================

Toolset for converting Ultima Underworld and System Shock 1 levels and objects into other engines. Primarily Unity but earlier versions supported Idtech 4, Source Engine. Most features are geared towards UW1. UW2&SS1 are in cryosleep at the moment but the basic process works for them.

Sample workspace and compiled version using Underworld 1 demo assets
http://www.mediafire.com/download/9pz6y5j3sf9l59c/uwdemo_dev.zip

Basic jist of what this does for creating in Unity.

Exports a map into a .fbx model.
Extracts the textures in specific order and naming
Extracts the game strings
Extracts the object and interface art.
Extracts the creature animation art and generates a script to make animation assets for them. Similarly for weapons
Extracts a big old editor script that re-creates the individual game objects to a T.

Attached UnityScripts for implementing vanilla game behaviour.

The tool is also a general purpose extractor, decompressor and data dumper.
