using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderworldEditor
{
    public class objects
    {
        public struct ObjectInfo
        {
            public int index;
            public int item_id; //0-8
            public short flags; //9-12
            public short enchantment;   //12
            public short doordir;   //13
            public short invis;     //14
            public short is_quant;  //15
            public short zpos;
            public short heading;
            public short xpos;
            public short ypos;
            public short quality;
            public int next;
            public short owner;
            public int link;
            public long FileAddress;
        }

        public ObjectInfo[] objList;

        public void InitInventoryObjectList(char[]buffer, int offset)
        {
            int NoOfItems = ((buffer.GetUpperBound(0) - offset) / 8) + 1;
            if(offset== buffer.GetUpperBound(0))
            { NoOfItems = 0; }
            if (NoOfItems==0)
            {
                objList = null;
                return;
            }
            objList = new ObjectInfo[NoOfItems+1];
            for (int i=0; i< NoOfItems ; i++)
            {
                objList[i+1] = initObject(buffer, offset + (i * 8));
                objList[i+1].index = i;
            }
        }

        public void InitWorldObjectList(char[] buffer, int offset, long blockaddress)
        {
            int NoOfItems = 1024;
            objList = new ObjectInfo[1025];
            int objectaddress = 0;
            for (int i = 0; i <= NoOfItems; i++)
            {
                objList[i] = initObject(buffer, offset + objectaddress);
                objList[i].FileAddress = blockaddress + objectaddress + offset;
                objList[i].index = i;
                if (i<=255)
                {
                    objectaddress = objectaddress + 8 + 19;
                }
                else
                {
                    objectaddress = objectaddress + 8;
                }
            }
        }


        static ObjectInfo initObject(char[]buffer, int objectsAddress)
        {
            ObjectInfo newObj = new ObjectInfo();

            int[] Vals = new int[4];
            //Read in the 4 x int 16s that comprise the static object
            for (int i = 0; i <= Vals.GetUpperBound(0); i++)
            {
                Vals[i] = (int)Util.getValAtAddress(buffer, objectsAddress + (i * 2), 16);
            }
            newObj.FileAddress = objectsAddress;
            //postion at +1
            newObj.item_id = (int)Util.ExtractBits(Vals[0], 0, 9);
            newObj.flags = (short)(Util.ExtractBits(Vals[0], 9, 3));
            newObj.enchantment = (short)(Util.ExtractBits(Vals[0], 12, 1));
            newObj.doordir = (short)(Util.ExtractBits(Vals[0], 13, 1));
            newObj.invis = (short)(Util.ExtractBits(Vals[0], 14, 1));
            newObj.is_quant = (short)(Util.ExtractBits(Vals[0], 15, 1));

            //position at +2
            newObj.zpos = (short)(Util.ExtractBits(Vals[1], 0, 7));  //bits 0-6 
            newObj.heading = (short)(Util.ExtractBits(Vals[1], 7, 3)); //bits 7-9
            newObj.ypos = (short)(Util.ExtractBits(Vals[1], 10, 3)); //bits 7-9	//bits 10-12
            newObj.xpos = (short)(Util.ExtractBits(Vals[1], 13, 3));    //bits 13-15
            //+4
            newObj.quality = (short)(Util.ExtractBits(Vals[2], 0, 6));
            newObj.next = (short)(Util.ExtractBits(Vals[2], 6, 10));

            //+6
            newObj.owner = (short)(Util.ExtractBits(Vals[3], 0, 6));//bits 0-5
            newObj.link = (short)(Util.ExtractBits(Vals[3], 6, 10)); //bits 6-15


            return newObj;
        }

        public static string ObjectName(int item_id, int game)
        {
            switch (game)
            {
                case 2:
                    return UW2ObjectName(item_id);
                default:
                    return UW1ObjectName(item_id);
            }
        }

        public static string UW1ObjectName(int item_id)
        {
            switch (item_id)
            {
                case 0: return "a_hand_axe";
                case 1: return "a_battle_axe";
                case 2: return "an_axe";
                case 3: return "a_dagger";
                case 4: return "a_shortsword";
                case 5: return "a_longsword";
                case 6: return "a_broadsword";
                case 7: return "a_cudgel";
                case 8: return "a_light_mace";
                case 9: return "a_mace";
                case 10: return "a_shiny_sword";
                case 11: return "a_jeweled_axe";
                case 12: return "a_black_sword";
                case 13: return "a_jeweled_sword";
                case 14: return "a_jeweled_mace";
                case 15: return "a_fist";
                case 16: return "a_sling_stone";
                case 17: return "a_crossbow_bolt";
                case 18: return "an_arrow";
                case 19: return "a_stone";
                case 20: return "a_fireball";
                case 21: return "a_lightning_bolt";
                case 22: return "acid";
                case 23: return "a_magic_missile";
                case 24: return "a_sling";
                case 25: return "a_bow";
                case 26: return "a_crossbow";
                case 27: return "unknown";
                case 28: return "unknown";
                case 29: return "unknown";
                case 30: return "unknown";
                case 31: return "a_jeweled_bow";
                case 32: return "a_leather_vest";
                case 33: return "a_mail_shirt";
                case 34: return "a_breastplate";
                case 35: return "leather_leggings_pairs_of_leather_leggings";
                case 36: return "mail_leggings_pairs_of_mail_leggings";
                case 37: return "plate_leggings_pairs_of_plate_leggings";
                case 38: return "leather_gloves_pairs_of_leather_gloves";
                case 39: return "chain_gauntlets_pairs_of_chain_gauntlets";
                case 40: return "plate_gauntlets_pairs_of_plate_gauntlets";
                case 41: return "leather_boots_pairs_of_leather_boots";
                case 42: return "chain_boots_pairs_of_chain_boots";
                case 43: return "plate_boots_pairs_of_plate_boots";
                case 44: return "a_leather_cap";
                case 45: return "a_chain_cowl";
                case 46: return "a_helmet";
                case 47: return "a_pair_of_dragon_skin_boots_pairs_of_dragon_skin_boots";
                case 48: return "a_crown";
                case 49: return "a_crown";
                case 50: return "a_crown";
                case 51: return "unknownring1";
                case 52: return "unknownring2";
                case 53: return "unknownring3";
                case 54: return "an_iron_ring";
                case 55: return "a_shiny_shield";
                case 56: return "a_gold_ring";
                case 57: return "a_silver_ring";
                case 58: return "a_red_ring";
                case 59: return "a_tower_shield";
                case 60: return "a_wooden_shield";
                case 61: return "a_small_shield";
                case 62: return "a_buckler";
                case 63: return "a_jeweled_shield";
                case 64: return "a_rotworm";
                case 65: return "a_flesh_slug";
                case 66: return "a_cave_bat";
                case 67: return "a_giant_rat";
                case 68: return "a_giant_spider";
                case 69: return "a_acid_slug";
                case 70: return "a_goblin";
                case 71: return "a_goblin";
                case 72: return "a_giant_rat";
                case 73: return "a_vampire_bat";
                case 74: return "a_skeleton";
                case 75: return "an_imp";
                case 76: return "a_goblin";
                case 77: return "a_goblin";
                case 78: return "a_goblin";
                case 79: return "etherealvoidcreatures";
                case 80: return "a_goblin";
                case 81: return "a_mongbat";
                case 82: return "a_bloodworm";
                case 83: return "a_wolf_spider";
                case 84: return "a_mountainman_mountainmen";
                case 85: return "a_green_lizardman_green_lizardmen";
                case 86: return "a_mountainman_mountainmen";
                case 87: return "a_lurker";
                case 88: return "a_red_lizardman_red_lizardmen";
                case 89: return "a_gray_lizardman_red_lizardmen";
                case 90: return "an_outcast";
                case 91: return "a_headless_headlesses";
                case 92: return "a_dread_spider";
                case 93: return "a_fighter";
                case 94: return "a_fighter";
                case 95: return "a_fighter";
                case 96: return "a_troll";
                case 97: return "a_ghost";
                case 98: return "a_fighter";
                case 99: return "a_ghoul";
                case 100: return "a_ghost";
                case 101: return "a_ghost";
                case 102: return "a_gazer";
                case 103: return "a_mage";
                case 104: return "a_fighter";
                case 105: return "a_dark_ghoul";
                case 106: return "a_mage";
                case 107: return "a_mage";
                case 108: return "a_mage";
                case 109: return "a_mage";
                case 110: return "a_ghoul";
                case 111: return "a_feral_troll";
                case 112: return "a_great_troll";
                case 113: return "a_dire_ghost";
                case 114: return "an_earth_golem";
                case 115: return "a_mage";
                case 116: return "a_deep_lurker";
                case 117: return "a_shadow_beast";
                case 118: return "a_reaper";
                case 119: return "a_stone_golem";
                case 120: return "a_fire_elemental";
                case 121: return "a_metal_golem";
                case 122: return "a_wisp";
                case 123: return "tybal";
                case 124: return "slasher_of_veils";
                case 125: return "etherealvoidcreatures";
                case 126: return "etherealvoidcreatures";
                case 127: return "an_adventurer";
                case 128: return "a_sack";
                case 129: return "an_open_sack";
                case 130: return "a_pack";
                case 131: return "an_open_pack";
                case 132: return "a_box_boxes";
                case 133: return "an_open_box_open_boxes";
                case 134: return "a_pouch_pouches";
                case 135: return "an_open_pouch_pouches";
                case 136: return "a_map_case";
                case 137: return "an_open_map_case";
                case 138: return "a_gold_coffer";
                case 139: return "an_open_gold_coffer";
                case 140: return "an_urn";
                case 141: return "a_quiver";
                case 142: return "a_bowl";
                case 143: return "a_rune_bag";
                case 144: return "a_lantern";
                case 145: return "a_torch_torches";
                case 146: return "a_candle";
                case 147: return "a_taper";
                case 148: return "a_lit_lantern";
                case 149: return "a_lit_torch";
                case 150: return "a_lit_candle";
                case 151: return "a_lit_taper";
                case 152: return "a_wand";
                case 153: return "a_wand";
                case 154: return "a_wand";
                case 155: return "a_wand";
                case 156: return "a_broken_wand";
                case 157: return "a_broken_wand";
                case 158: return "a_broken_wand";
                case 159: return "a_broken_wand";
                case 160: return "a_coin";
                case 161: return "a_gold_coin";
                case 162: return "a_ruby_rubies";
                case 163: return "a_red_gem";
                case 164: return "a_small_blue_gem";
                case 165: return "a_large_blue_gem";
                case 166: return "a_sapphire";
                case 167: return "an_emerald";
                case 168: return "an_amulet";
                case 169: return "a_goblet";
                case 170: return "a_sceptre";
                case 171: return "a_gold_chain";
                case 172: return "a_gold_plate";
                case 173: return "an_ankh_pendant";
                case 174: return "a_shiny_cup";
                case 175: return "a_large_gold_nugget";
                case 176: return "a_piece_of_meat_pieces_of_meat";
                case 177: return "a_loaf_of_bread_loaves_of_bread";
                case 178: return "a_piece_of_cheese_pieces_of_cheese";
                case 179: return "an_apple";
                case 180: return "an_ear_of_corn_ears_of_corn";
                case 181: return "a_loaf_of_bread_loaves_of_bread";
                case 182: return "a_fish_fish";
                case 183: return "some_popcorn_bunches_of_popcorn";
                case 184: return "a_mushroom";
                case 185: return "a_toadstool";
                case 186: return "a_bottle_of_ale_bottles_of_ale";
                case 187: return "a_red_potion";
                case 188: return "a_green_potion";
                case 189: return "a_bottle_of_water_bottles_of_water";
                case 190: return "a_flask_of_port_flasks_of_port";
                case 191: return "a_bottle_of_wine_bottles_of_wine";
                case 192: return "a_plant";
                case 193: return "some_grass_bunches_of_grass";
                case 194: return "a_skull";
                case 195: return "a_skull";
                case 196: return "a_bone";
                case 197: return "a_bone";
                case 198: return "a_pile_of_bones_piles_of_bones";
                case 199: return "some_vines_bunches_of_vines";
                case 200: return "a_broken_axe";
                case 201: return "a_broken_sword";
                case 202: return "a_broken_mace";
                case 203: return "a_broken_shield";
                case 204: return "a_piece_of_wood_pieces_of_wood";
                case 205: return "a_piece_of_wood_pieces_of_wood";
                case 206: return "a_plant";
                case 207: return "a_plant";
                case 208: return "a_pile_of_debris_piles_of_debris";
                case 209: return "a_pile_of_debris_piles_of_debris";
                case 210: return "a_pile_of_debris_piles_of_debris";
                case 211: return "a_stalactite";
                case 212: return "a_plant";
                case 213: return "a_pile_of_debris_piles_of_debris";
                case 214: return "a_pile_of_debris_piles_of_debris";
                case 215: return "an_anvil";
                case 216: return "a_pole";
                case 217: return "a_dead_rotworm";
                case 218: return "some_rubble_piles_of_rubble";
                case 219: return "a_pile_of_wood_chips_piles_of_wood_chips";
                case 220: return "a_pile_of_bones_piles_of_bones";
                case 221: return "a_blood_stain";
                case 222: return "a_blood_stain";
                case 223: return "a_blood_stain";
                case 224: return "a_runestone";
                case 225: return "the_Key_of_Truth";
                case 226: return "the_Key_of_Love";
                case 227: return "the_Key_of_Courage";
                case 228: return "a_two_part_key";
                case 229: return "a_two_part_key";
                case 230: return "a_two_part_key";
                case 231: return "the_Key_of_Infinity";
                case 232: return "an_An_stone";
                case 233: return "a_Bet_stone";
                case 234: return "a_Corp_stone";
                case 235: return "a_Des_stone";
                case 236: return "an_Ex_stone";
                case 237: return "a_Flam_stone";
                case 238: return "a_Grav_stone";
                case 239: return "a_Hur_stone";
                case 240: return "an_In_stone";
                case 241: return "a_Jux_stone";
                case 242: return "a_Kal_stone";
                case 243: return "a_Lor_stone";
                case 244: return "a_Mani_stone";
                case 245: return "a_Nox_stone";
                case 246: return "an_Ort_stone";
                case 247: return "a_Por_stone";
                case 248: return "a_Quas_stone";
                case 249: return "a_Rel_stone";
                case 250: return "a_Sanct_stone";
                case 251: return "a_Tym_stone";
                case 252: return "an_Uus_stone";
                case 253: return "a_Vas_stone";
                case 254: return "a_Wis_stone";
                case 255: return "a_Ylem_stone";
                case 256: return "a_key";
                case 257: return "a_lockpick";
                case 258: return "a_key";
                case 259: return "a_key";
                case 260: return "a_key";
                case 261: return "a_key";
                case 262: return "a_key";
                case 263: return "a_key";
                case 264: return "a_key";
                case 265: return "a_key";
                case 266: return "a_key";
                case 267: return "a_key";
                case 268: return "a_key";
                case 269: return "a_key";
                case 270: return "a_key";
                case 271: return "a_lock";
                case 272: return "a_picture_of_Tom";
                case 273: return "a_crystal_splinter";
                case 274: return "an_orb_rock";
                case 275: return "the_Gem_Cutter_of_Coulnes";
                case 276: return "a_book";
                case 277: return "a_block_of_burning_incense_blocks_of_burning_incense";
                case 278: return "a_block_of_incense_blocks_of_incense";
                case 279: return "an_orb";
                case 280: return "a_broken_blade";
                case 281: return "a_broken_hilt";
                case 282: return "a_figurine";
                case 283: return "some_rotworm_stew_servings_of_rotworm_stew";
                case 284: return "some_strong_thread_pieces_of_strong_thread";
                case 285: return "dragon_scales_bunches_of_dragon_scales";
                case 286: return "a_resilient_sphere_some_resilient_spheres";
                case 287: return "a_standard";
                case 288: return "a_spell";
                case 289: return "a_bedroll";
                case 290: return "a_silver_seed";
                case 291: return "a_mandolin";
                case 292: return "a_flute";
                case 293: return "some_leeches_bunches_of_leeches";
                case 294: return "a_moonstone";
                case 295: return "a_spike";
                case 296: return "a_rock_hammer";
                case 297: return "a_glowing_rock";
                case 298: return "a_campfire";
                case 299: return "a_fishing_pole";
                case 300: return "a_medallion";
                case 301: return "an_oil_flask";
                case 302: return "a_fountain";
                case 303: return "a_cauldron";
                case 304: return "a_book";
                case 305: return "a_book";
                case 306: return "a_book";
                case 307: return "a_book";
                case 308: return "a_book";
                case 309: return "a_book";
                case 310: return "a_book";
                case 311: return "a_book";
                case 312: return "a_scroll";
                case 313: return "a_scroll";
                case 314: return "a_scroll";
                case 315: return "a_map";
                case 316: return "a_scroll";
                case 317: return "a_scroll";
                case 318: return "a_scroll";
                case 319: return "a_scroll";
                case 320: return "a_door";
                case 321: return "a_door";
                case 322: return "a_door";
                case 323: return "a_door";
                case 324: return "a_door";
                case 325: return "a_door";
                case 326: return "a_portcullis_portcullises";
                case 327: return "a_secret_door";
                case 328: return "an_open_door";
                case 329: return "an_open_door";
                case 330: return "an_open_door";
                case 331: return "an_open_door";
                case 332: return "an_open_door";
                case 333: return "an_open_door";
                case 334: return "an_open_portcullis";
                case 335: return "a_secret_door";
                case 336: return "a_bench_benches";
                case 337: return "an_arrow";
                case 338: return "a_crossbow_bolt";
                case 339: return "a_large_boulder";
                case 340: return "a_large_boulder";
                case 341: return "a_boulder";
                case 342: return "a_small_boulder";
                case 343: return "a_shrine";
                case 344: return "a_table";
                case 345: return "a_beam";
                case 346: return "a_moongate";
                case 347: return "a_barrel";
                case 348: return "a_chair";
                case 349: return "a_chest";
                case 350: return "a_nightstand";
                case 351: return "a_lotus_turbo_esprit";
                case 352: return "a_pillar";
                case 353: return "a_lever";
                case 354: return "a_switch_switches";
                case 355: return "unknown";
                case 356: return "a_bridge";
                case 357: return "a_gravestone";
                case 358: return "some_writing";
                case 359: return "unknown";
                case 360: return "unknown";
                case 361: return "unknown";
                case 362: return "unknown";
                case 363: return "unknown";
                case 364: return "unknown";
                case 365: return "force_field";
                case 366: return "special_tmap_obj";
                case 367: return "special_tmap_obj";
                case 368: return "a_button";
                case 369: return "a_button";
                case 370: return "a_button";
                case 371: return "a_switch";
                case 372: return "a_switch";
                case 373: return "a_lever";
                case 374: return "a_pull_chain";
                case 375: return "a_pull_chain";
                case 376: return "a_button";
                case 377: return "a_button";
                case 378: return "a_button";
                case 379: return "a_switch";
                case 380: return "a_switch";
                case 381: return "a_lever";
                case 382: return "a_pull_chain";
                case 383: return "a_pull_chain";
                case 384: return "a_damage_trap";
                case 385: return "a_teleport_trap";
                case 386: return "a_arrow_trap";
                case 387: return "a_do_trap";
                case 388: return "a_pit_trap";
                case 389: return "a_change_terrain_trap";
                case 390: return "a_spelltrap";
                case 391: return "a_create_object_trap";
                case 392: return "a_door_trap";
                case 393: return "a_ward_trap";
                case 394: return "a_tell_trap";
                case 395: return "a_delete_object_trap";
                case 396: return "an_inventory_trap";
                case 397: return "a_set_variable_trap";
                case 398: return "a_check_variable_trap";
                case 399: return "a_combination_trap";
                case 400: return "a_text_string_trap";
                case 401: return "unknown";
                case 402: return "unknown";
                case 403: return "unknown";
                case 404: return "unknown";
                case 405: return "unknown";
                case 406: return "unknown";
                case 407: return "unknown";
                case 408: return "unknown";
                case 409: return "unknown";
                case 410: return "unknown";
                case 411: return "unknown";
                case 412: return "unknown";
                case 413: return "unknown";
                case 414: return "unknown";
                case 415: return "unknown";
                case 416: return "a_move_trigger";
                case 417: return "a_pick_up_trigger";
                case 418: return "a_use_trigger";
                case 419: return "a_look_trigger";
                case 420: return "a_step_on_trigger";
                case 421: return "an_open_trigger";
                case 422: return "an_unlock_trigger";
                case 423: return "unknown";
                case 424: return "unknown";
                case 425: return "unknown";
                case 426: return "unknown";
                case 427: return "unknown";
                case 428: return "unknown";
                case 429: return "unknown";
                case 430: return "unknown";
                case 431: return "unknown";
                case 432: return "unknown";
                case 433: return "unknown";
                case 434: return "unknown";
                case 435: return "unknown";
                case 436: return "unknown";
                case 437: return "unknown";
                case 438: return "unknown";
                case 439: return "unknown";
                case 440: return "unknown";
                case 441: return "unknown";
                case 442: return "unknown";
                case 443: return "unknown";
                case 444: return "unknown";
                case 445: return "unknown";
                case 446: return "unknown";
                case 447: return "unknown";
                case 448: return "some_blood";
                case 449: return "a_mist_cloud";
                case 450: return "an_explosion";
                case 451: return "an_explosion";
                case 452: return "an_explosion";
                case 453: return "a_splash_splashes";
                case 454: return "a_splash_splahes";
                case 455: return "a_spell_effect";
                case 456: return "some_smoke";
                case 457: return "a_fountain";
                case 458: return "a_silver_tree";
                case 459: return "some_damage";
                case 460: return "unknown";
                case 461: return "a_sound_source";
                case 462: return "some_changing_terrain";
                case 463: return "a_moving_door";
                case 464:
                default:
                    return "outofrange";
            }
        }
        
        public static string UW2ObjectName(int item_id)
        {
            switch (item_id)
            {
                case 0: return "a_hand_axe";
                case 1: return "a_battle_axe";
                case 2: return "an_axe";
                case 3: return "a_dagger";
                case 4: return "a_shortsword";
                case 5: return "a_longsword";
                case 6: return "a_broadsword";
                case 7: return "a_cudgel";
                case 8: return "a_light_mace";
                case 9: return "a_mace";
                case 10: return "a_jewelled_dagger";
                case 11: return "a_jeweled_axe";
                case 12: return "a_black_sword";
                case 13: return "a_jeweled_sword";
                case 14: return "a_jeweled_mace";
                case 15: return "a_fist";
                case 16: return "a_sling_stone";
                case 17: return "a_crossbow_bolt";
                case 18: return "an_arrow";
                case 19: return "a_skull";
                case 20: return "a_fireball";
                case 21: return "a_lightning_bolt";
                case 22: return "acid";
                case 23: return "a_magic_arrow";
                case 24: return "a_sling";
                case 25: return "a_bow";
                case 26: return "a_crossbow";
                case 27: return "a_homing_dart";
                case 28: return "a_snowball";
                case 29: return "a_fireball";
                case 30: return "a_satellite";
                case 31: return "a_jeweled_bow";
                case 32: return "a_leather_vest";
                case 33: return "a_mail_shirt";
                case 34: return "a_breastplate";
                case 35: return "leather_leggings&pairs_of_leather_leggings";
                case 36: return "mail_leggings&pairs_of_mail_leggings";
                case 37: return "plate_leggings&pairs_of_plate_leggings";
                case 38: return "leather_gloves&pairs_of_leather_gloves";
                case 39: return "chain_gauntlets&pairs_of_chain_gauntlets";
                case 40: return "plate_gauntlets&pairs_of_plate_gauntlets";
                case 41: return "leather_boots&pairs_of_leather_boots";
                case 42: return "chain_boots&pairs_of_chain_boots";
                case 43: return "plate_boots&pairs_of_plate_boots";
                case 44: return "a_leather_cap";
                case 45: return "a_chain_cowl";
                case 46: return "a_helmet";
                case 47: return "a_pair_of_swamp_boots&pairs_of_swamp_boots";
                case 48: return "a_crown";
                case 49: return "a_crown";
                case 50: return "a_crown";
                case 51: return "fraznium_gauntlets&pairs_of_fraznium_gauntlets";
                case 52: return "a_fraznium_circlet";
                case 53: return "a_Guardian_signet_ring";
                case 54: return "a_strange_artifact";
                case 55: return "a_copper_ring";
                case 56: return "a_gold_ring";
                case 57: return "a_silver_ring";
                case 58: return "a_red_ring";
                case 59: return "a_tower_shield";
                case 60: return "a_wooden_shield";
                case 61: return "a_small_shield";
                case 62: return "a_buckler";
                case 63: return "a_jeweled_shield";
                case 64: return "a_rotworm";
                case 65: return "a_cave_bat";
                case 66: return "a_vampire_bat";
                case 67: return "a_giant_tan_rat";
                case 68: return "a_giant_grey_rat";
                case 69: return "a_flesh_slug";
                case 70: return "an_acid_slug";
                case 71: return "a_mongbat";
                case 72: return "a_skeleton";
                case 73: return "a_goblin";
                case 74: return "a_goblin";
                case 75: return "an_imp";
                case 76: return "a_giant_spider";
                case 77: return "a_lurker";
                case 78: return "a_bloodworm";
                case 79: return "a_stickman";
                case 80: return "a_white_worm";
                case 81: return "a_snow_cat";
                case 82: return "a_yeti&yeti";
                case 83: return "a_headless&headlesses";
                case 84: return "a_Talorid";
                case 85: return "a_ghost";
                case 86: return "a_wolf_spider";
                case 87: return "a_trilkhun&trilkhai";
                case 88: return "a_brain_creature";
                case 89: return "a_deep_lurker";
                case 90: return "a_dread_spider";
                case 91: return "a_human";
                case 92: return "a_great_troll";
                case 93: return "a_spectre";
                case 94: return "a_hordling";
                case 95: return "an_earth_golem";
                case 96: return "a_fire_elemental";
                case 97: return "an_ice_golem";
                case 98: return "a_dire_ghost";
                case 99: return "a_reaper";
                case 100: return "a_despoiler";
                case 101: return "a_metal_golem";
                case 102: return "a_haunt";
                case 103: return "a_dire_reaper";
                case 104: return "a_destroyer";
                case 105: return "a_liche";
                case 106: return "a_liche";
                case 107: return "a_liche";
                case 108: return "a_human";
                case 109: return "a_vorz";
                case 110: return "a_fighter";
                case 111: return "a_gazer";
                case 112: return "a_human";
                case 113: return "a_human";
                case 114: return "a_human";
                case 115: return "a_human";
                case 116: return "a_human";
                case 117: return "a_human";
                case 118: return "a_human";
                case 119: return "a_human";
                case 120: return "a_human";
                case 121: return "a_human";
                case 122: return "a_human";
                case 123: return "a_human";
                case 124: return "etherealvoidshit";
                case 125: return "etherealvoidshit";
                case 126: return "a_human";
                case 127: return "an_adventurer";
                case 128: return "a_sack";
                case 129: return "an_open_sack";
                case 130: return "a_pack";
                case 131: return "an_open_pack";
                case 132: return "a_box&boxes";
                case 133: return "an_open_box&open_boxes";
                case 134: return "a_pouch&pouches";
                case 135: return "an_open_pouch&pouches";
                case 136: return "a_map_case";
                case 137: return "an_open_map_case";
                case 138: return "a_gold_coffer";
                case 139: return "an_open_gold_coffer";
                case 140: return "a_key_ring";
                case 141: return "a_quiver";
                case 142: return "a_bowl";
                case 143: return "a_rune_bag";
                case 144: return "a_lantern";
                case 145: return "a_torch&torches";
                case 146: return "a_candle";
                case 147: return "a_light-sphere";
                case 148: return "a_lit_lantern";
                case 149: return "a_lit_torch";
                case 150: return "a_lit_candle";
                case 151: return "a_lit_light-sphere";
                case 152: return "a_wand";
                case 153: return "a_wand";
                case 154: return "a_wand";
                case 155: return "a_wand";
                case 156: return "a_broken_wand";
                case 157: return "a_broken_wand";
                case 158: return "a_broken_wand";
                case 159: return "a_broken_wand";
                case 160: return "a_coin";
                case 161: return "a_storage_crystal";
                case 162: return "a_ruby&rubies";
                case 163: return "a_red_gem";
                case 164: return "a_small_blue_gem";
                case 165: return "a_large_blue_gem";
                case 166: return "a_sapphire";
                case 167: return "an_emerald";
                case 168: return "a_black_pearl";
                case 169: return "a_goblet";
                case 170: return "a_sceptre";
                case 171: return "a_black_stone";
                case 172: return "a_white_stone";
                case 173: return "a_grey_stone";
                case 174: return "a_delgnigzator";
                case 175: return "a_pocketwatch&pocketwatches";
                case 176: return "a_piece_of_meat&pieces_of_meat";
                case 177: return "a_piece_of_meat&pieces_of_meat";
                case 178: return "a_piece_of_cheese&pieces_of_cheese";
                case 179: return "an_apple";
                case 180: return "an_ear_of_corn&ears_of_corn";
                case 181: return "a_loaf_of_bread&loaves_of_bread";
                case 182: return "a_fish&fish";
                case 183: return "some_popcorn&bunches_of_popcorn";
                case 184: return "a_pastry&pastries";
                case 185: return "a_mushroom";
                case 186: return "a_honeycomb";
                case 187: return "a_bottle_of_ale&bottles_of_ale";
                case 188: return "a_bottle_of_water&bottles_of_water";
                case 189: return "a_bottle_of_wine&bottles_of_wine";
                case 190: return "some_meat-on-a-stick&pieces_of_meat-on-a-stick";
                case 191: return "a_nutritious_wafer";
                case 192: return "a_plant";
                case 193: return "some_grass&bunches_of_grass";
                case 194: return "a_skull";
                case 195: return "a_skull";
                case 196: return "a_bone";
                case 197: return "a_bone";
                case 198: return "a_pile_of_bones&piles_of_bones";
                case 199: return "a_broken_dagger";
                case 200: return "a_broken_sword";
                case 201: return "a_broken_axe";
                case 202: return "a_broken_mace";
                case 203: return "a_broken_shield";
                case 204: return "a_piece_of_wood&pieces_of_wood";
                case 205: return "a_piece_of_wood&pieces_of_wood";
                case 206: return "a_plant";
                case 207: return "a_plant";
                case 208: return "a_pile_of_debris&piles_of_debris";
                case 209: return "a_pile_of_debris&piles_of_debris";
                case 210: return "a_lump_of_wax&lumps_of_wax";
                case 211: return "a_stalactite";
                case 212: return "a_plant";
                case 213: return "an_icicle";
                case 214: return "a_pile_of_debris&piles_of_debris";
                case 215: return "an_anvil";
                case 216: return "a_pole";
                case 217: return "a_plant";
                case 218: return "a_plant";
                case 219: return "some_rubble&piles_of_rubble";
                case 220: return "a_pile_of_wood_chips&piles_of_wood_chips";
                case 221: return "a_pile_of_bones&piles_of_bones";
                case 222: return "a_blood_stain";
                case 223: return "a_blood_stain";
                case 224: return "a_runestone";
                case 225: return "a_black_potion";
                case 226: return "a_purple_potion";
                case 227: return "a_yellow_potion";
                case 228: return "a_green_potion";
                case 229: return "a_red_potion";
                case 230: return "a_colorless_potion";
                case 231: return "a_brown_potion";
                case 232: return "an_An_stone";
                case 233: return "a_Bet_stone";
                case 234: return "a_Corp_stone";
                case 235: return "a_Des_stone";
                case 236: return "an_Ex_stone";
                case 237: return "a_Flam_stone";
                case 238: return "a_Grav_stone";
                case 239: return "a_Hur_stone";
                case 240: return "an_In_stone";
                case 241: return "a_Jux_stone";
                case 242: return "a_Kal_stone";
                case 243: return "a_Lor_stone";
                case 244: return "a_Mani_stone";
                case 245: return "a_Nox_stone";
                case 246: return "an_Ort_stone";
                case 247: return "a_Por_stone";
                case 248: return "a_Quas_stone";
                case 249: return "a_Rel_stone";
                case 250: return "a_Sanct_stone";
                case 251: return "a_Tym_stone";
                case 252: return "an_Uus_stone";
                case 253: return "a_Vas_stone";
                case 254: return "a_Wis_stone";
                case 255: return "a_Ylem_stone";
                case 256: return "a_curious_implement";
                case 257: return "a_lockpick";
                case 258: return "a_key";
                case 259: return "a_key";
                case 260: return "a_key";
                case 261: return "a_key";
                case 262: return "a_key";
                case 263: return "a_key";
                case 264: return "a_key";
                case 265: return "a_key";
                case 266: return "a_key";
                case 267: return "a_key";
                case 268: return "a_key";
                case 269: return "a_key";
                case 270: return "a_key";
                case 271: return "a_lock";
                case 272: return "an_eyeball";
                case 273: return "a_horn";
                case 274: return "a_pearl-tipped_rod&pearl-tipped_rods";
                case 275: return "a_black_eggshell&black_eggshells";
                case 276: return "a_plant";
                case 277: return "a_serpent_statue&serpent_statues";
                case 278: return "a_bottle";
                case 279: return "an_amethyst_rod&amethyst_rods";
                case 280: return "a_blackrock_gem";
                case 281: return "a_blackrock_gem";
                case 282: return "a_blackrock_gem";
                case 283: return "a_blackrock_gem";
                case 284: return "a_blackrock_gem";
                case 285: return "a_blackrock_gem";
                case 286: return "a_blackrock_gem";
                case 287: return "a_blackrock_gem";
                case 288: return "a_spell";
                case 289: return "a_bedroll";
                case 290: return "an_orb";
                case 291: return "a_mandolin";
                case 292: return "a_flute";
                case 293: return "some_leeches&bunches_of_leeches";
                case 294: return "a_moonstone";
                case 295: return "a_force_field";
                case 296: return "a_rock_hammer";
                case 297: return "a_resilient_sphere";
                case 298: return "a_campfire";
                case 299: return "a_fishing_pole";
                case 300: return "some_thread&pieces_of_thread";
                case 301: return "an_oil_flask";
                case 302: return "a_fountain";
                case 303: return "a_banner";
                case 304: return "a_book";
                case 305: return "a_book";
                case 306: return "a_book";
                case 307: return "a_book";
                case 308: return "a_scroll";
                case 309: return "a_scroll";
                case 310: return "a_scroll";
                case 311: return "a_scroll";
                case 312: return "a_book";
                case 313: return "a_bit_of_a_map";
                case 314: return "a_map";
                case 315: return "a_dead_plant";
                case 316: return "a_dead_plant";
                case 317: return "a_bottle";
                case 318: return "a_stick";
                case 319: return "a_resilient_sphere";
                case 320: return "a_door";
                case 321: return "a_door";
                case 322: return "a_door";
                case 323: return "a_door";
                case 324: return "a_door";
                case 325: return "a_door";
                case 326: return "a_portcullis&portcullises";
                case 327: return "a_secret_door";
                case 328: return "an_open_door";
                case 329: return "an_open_door";
                case 330: return "an_open_door";
                case 331: return "an_open_door";
                case 332: return "an_open_door";
                case 333: return "an_open_door";
                case 334: return "an_open_portcullis";
                case 335: return "a_secret_door";
                case 336: return "a_bench&benches";
                case 337: return "an_arrow";
                case 338: return "a_crossbow_bolt";
                case 339: return "a_large_boulder";
                case 340: return "a_large_boulder";
                case 341: return "a_boulder";
                case 342: return "a_small_boulder";
                case 343: return "a_shrine";
                case 344: return "a_table";
                case 345: return "a_beam";
                case 346: return "a_moongate";
                case 347: return "a_barrel";
                case 348: return "a_chair";
                case 349: return "a_chest";
                case 350: return "a_nightstand";
                case 351: return "a_lotus_turbo_esprit";
                case 352: return "a_pillar";
                case 353: return "a_lever";
                case 354: return "a_switch&switches";
                case 355: return "a_painting";
                case 356: return "a_bridge";
                case 357: return "a_gravestone";
                case 358: return "some_writing";
                case 359: return "a_bed";
                case 360: return "a_large_blackrock_gem";
                case 361: return "a_shelf";
                case 362: return "unknown";
                case 363: return "unknown";
                case 364: return "unknown";
                case 365: return "force_field";
                case 366: return "special_tmap_obj";
                case 367: return "special_tmap_obj";
                case 368: return "a_button";
                case 369: return "a_button";
                case 370: return "a_button";
                case 371: return "a_switch";
                case 372: return "a_switch";
                case 373: return "a_lever";
                case 374: return "a_pull_chain";
                case 375: return "a_pull_chain";
                case 376: return "a_button";
                case 377: return "a_button";
                case 378: return "a_button";
                case 379: return "a_switch";
                case 380: return "a_switch";
                case 381: return "a_lever";
                case 382: return "a_pull_chain";
                case 383: return "a_pull_chain";
                case 384: return "a_damage_trap";
                case 385: return "a_teleport_trap";
                case 386: return "a_arrow_trap";
                case 387: return "a_hack_trap";
                case 388: return "a_special_effects_trap";
                case 389: return "a_change_terrain_trap";
                case 390: return "a_spelltrap";
                case 391: return "a_create_object_trap";
                case 392: return "a_door_trap";
                case 393: return "a_ward_trap";
                case 394: return "a_skill_trap";
                case 395: return "a_delete_object_trap";
                case 396: return "an_inventory_trap";
                case 397: return "a_set_variable_trap";
                case 398: return "a_check_variable_trap";
                case 399: return "a_null_trap";
                case 400: return "a_text_string_trap";
                case 401: return "an_experience_trap";
                case 402: return "a_jump_trap";
                case 403: return "a_change_from_trap";
                case 404: return "a_change_to_trap";
                case 405: return "an_oscillator_trap";
                case 406: return "a_proximity_trap";
                case 407: return "a_pit_trap";
                case 408: return "a_bridge_trap";
                case 409: return "unknown";
                case 410: return "unknown";
                case 411: return "unknown";
                case 412: return "unknown";
                case 413: return "unknown";
                case 414: return "a_flam_rune";
                case 415: return "a_tym_rune";
                case 416: return "a_move_trigger";
                case 417: return "a_pick_up_trigger";
                case 418: return "a_use_trigger";
                case 419: return "a_look_trigger";
                case 420: return "a_pressure_trigger";
                case 421: return "a_pressure_release_trigger";
                case 422: return "an_enter_trigger";
                case 423: return "an_exit_trigger";
                case 424: return "an_unlock_trigger";
                case 425: return "a_timer_trigger";
                case 426: return "an_open_trigger";
                case 427: return "a_close_trigger";
                case 428: return "a_scheduled_trigger";
                case 429: return "unknown";
                case 430: return "unknown";
                case 431: return "unknown";
                case 432: return "a_move_trigger";
                case 433: return "a_pick_up_trigger";
                case 434: return "a_use_trigger";
                case 435: return "a_look_trigger";
                case 436: return "a_pressure_trigger";
                case 437: return "a_pressure_release_trigger";
                case 438: return "an_enter_trigger";
                case 439: return "an_exit_trigger";
                case 440: return "an_unlock_trigger";
                case 441: return "a_timer_trigger";
                case 442: return "an_open_trigger";
                case 443: return "a_close_trigger";
                case 444: return "a_scheduled_trigger";
                case 445: return "unknown";
                case 446: return "unknown";
                case 447: return "unknown";
                case 448: return "some_blood";
                case 449: return "a_mist_cloud";
                case 450: return "an_explosion";
                case 451: return "an_explosion";
                case 452: return "an_explosion";
                case 453: return "lightning";
                case 454: return "a_splash&splashes";
                case 455: return "some_spacey_twinkles";
                case 456: return "some_smoke";
                case 457: return "a_fountain";
                case 458: return "some_frost";
                case 459: return "a_flash";
                case 460: return "lightning";
                case 461: return "a_wisp";
                case 462: return "a_vapor_trail";
                case 463: return "a_moving_door";
                default: return "outofrange";
            }
        }


        public static bool isContainer(int item_id)
        {//TODO:include NPCS
            switch (item_id)
            {
                case 128://a_sack
                case 129://an_open_sack
                case 130://a_pack
                case 131://an_open_pack
                case 132://a_box_boxes
                case 133://an_open_box_open_boxes
                case 134://a_pouch_pouches
                case 135://an_open_pouch_pouches
                case 136://a_map_case
                case 137://an_open_map_case
                case 138://a_gold_coffer
                case 139://an_open_gold_coffer
                case 140://an_urn
                case 141://a_quiver
                case 142://a_bowl
                case 347://a barrel
                case 349://achest
                    return true;
                default:
                    if (item_id>=64 && item_id<=126)
                    {
                        return true;
                    }
                    return false;
            }
        }
    }
}
