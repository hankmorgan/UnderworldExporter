using UnityEngine;
using System.Collections;

/// <summary>
/// Palette class for texture cycling effects. A cycled and default uncycled palette are stored.
/// </summary>
public class UWPalette : UWEBase {

		float[] red = new float[256];
		float[] blue = new float[256];
		float[] green = new float[256];

		float[] Defred = new float[256];
		float[] Defblue = new float[256];
		float[] Defgreen = new float[256];

		void Awake () {
				//Set the palette RGB values
				SetPal(0,0,0,4);
				SetPal(1,0,0,0);
				SetPal(2,252,148,252);
				SetPal(3,0,0,0);
				SetPal(4,4,0,4);
				SetPal(5,252,184,0);
				SetPal(6,252,108,0);
				SetPal(7,180,24,24);
				SetPal(8,124,184,252);
				SetPal(9,8,8,8);
				SetPal(10,124,192,120);
				SetPal(11,252,252,252);
				SetPal(12,96,236,252);
				SetPal(13,12,252,160);
				SetPal(14,252,124,108);
				SetPal(15,16,16,16);
				SetPal(16,240,136,4);
				SetPal(17,216,92,0);
				SetPal(18,200,56,0);
				SetPal(19,184,24,0);
				SetPal(20,168,0,0);
				SetPal(21,252,212,0);
				SetPal(22,244,148,0);
				SetPal(23,236,116,4);
				SetPal(24,108,128,132);
				SetPal(25,100,120,124);
				SetPal(26,92,108,112);
				SetPal(27,84,100,104);
				SetPal(28,72,92,96);
				SetPal(29,64,84,88);
				SetPal(30,56,72,76);
				SetPal(31,48,64,68);
				SetPal(32,184,120,92);
				SetPal(33,176,104,76);
				SetPal(34,168,92,60);
				SetPal(35,164,84,52);
				SetPal(36,148,76,40);
				SetPal(37,140,72,36);
				SetPal(38,132,68,32);
				SetPal(39,124,64,28);
				SetPal(40,176,136,104);
				SetPal(41,156,120,92);
				SetPal(42,140,104,84);
				SetPal(43,124,88,68);
				SetPal(44,96,68,52);
				SetPal(45,76,56,40);
				SetPal(46,60,40,32);
				SetPal(47,48,32,24);
				SetPal(48,20,40,112);
				SetPal(49,16,24,88);
				SetPal(50,16,36,96);
				SetPal(51,24,56,132);
				SetPal(52,20,32,104);
				SetPal(53,16,20,76);
				SetPal(54,16,28,88);
				SetPal(55,20,48,124);
				SetPal(56,16,24,96);
				SetPal(57,16,16,68);
				SetPal(58,16,20,76);
				SetPal(59,20,36,112);
				SetPal(60,16,20,88);
				SetPal(61,16,16,60);
				SetPal(62,16,16,68);
				SetPal(63,20,32,104);
				SetPal(64,92,228,252);
				SetPal(65,84,208,240);
				SetPal(66,76,196,220);
				SetPal(67,68,180,204);
				SetPal(68,60,164,184);
				SetPal(69,56,148,168);
				SetPal(70,52,136,148);
				SetPal(71,48,124,136);
				SetPal(72,40,108,124);
				SetPal(73,36,100,108);
				SetPal(74,32,88,100);
				SetPal(75,28,72,88);
				SetPal(76,24,64,72);
				SetPal(77,20,56,60);
				SetPal(78,16,40,48);
				SetPal(79,16,32,36);
				SetPal(80,208,252,12);
				SetPal(81,196,240,12);
				SetPal(82,180,220,12);
				SetPal(83,172,204,12);
				SetPal(84,160,184,12);
				SetPal(85,144,168,12);
				SetPal(86,132,148,12);
				SetPal(87,124,136,12);
				SetPal(88,112,124,12);
				SetPal(89,100,108,12);
				SetPal(90,92,100,12);
				SetPal(91,84,88,12);
				SetPal(92,68,72,12);
				SetPal(93,60,60,12);
				SetPal(94,48,48,12);
				SetPal(95,36,36,12);
				SetPal(96,252,252,252);
				SetPal(97,232,232,240);
				SetPal(98,204,204,220);
				SetPal(99,184,184,204);
				SetPal(100,164,164,184);
				SetPal(101,140,140,168);
				SetPal(102,124,124,148);
				SetPal(103,108,108,136);
				SetPal(104,100,100,124);
				SetPal(105,88,88,108);
				SetPal(106,76,76,100);
				SetPal(107,64,64,88);
				SetPal(108,56,56,72);
				SetPal(109,48,48,60);
				SetPal(110,36,36,48);
				SetPal(111,28,28,36);
				SetPal(112,252,228,136);
				SetPal(113,240,212,132);
				SetPal(114,220,196,124);
				SetPal(115,204,180,120);
				SetPal(116,184,168,108);
				SetPal(117,168,156,100);
				SetPal(118,156,140,96);
				SetPal(119,140,128,84);
				SetPal(120,128,112,72);
				SetPal(121,112,100,64);
				SetPal(122,100,92,56);
				SetPal(123,88,76,48);
				SetPal(124,72,64,36);
				SetPal(125,60,56,32);
				SetPal(126,52,40,24);
				SetPal(127,36,32,20);
				SetPal(128,252,156,136);
				SetPal(129,240,140,124);
				SetPal(130,220,128,108);
				SetPal(131,204,112,96);
				SetPal(132,184,104,84);
				SetPal(133,168,92,72);
				SetPal(134,156,84,64);
				SetPal(135,140,68,56);
				SetPal(136,128,60,52);
				SetPal(137,112,52,40);
				SetPal(138,100,48,36);
				SetPal(139,88,36,32);
				SetPal(140,72,28,28);
				SetPal(141,60,24,24);
				SetPal(142,52,20,20);
				SetPal(143,36,16,16);
				SetPal(144,252,252,252);
				SetPal(145,240,240,240);
				SetPal(146,220,220,220);
				SetPal(147,204,204,204);
				SetPal(148,184,184,184);
				SetPal(149,168,168,168);
				SetPal(150,148,148,148);
				SetPal(151,136,136,136);
				SetPal(152,124,124,124);
				SetPal(153,108,108,108);
				SetPal(154,100,100,100);
				SetPal(155,88,88,88);
				SetPal(156,72,72,72);
				SetPal(157,60,60,60);
				SetPal(158,48,48,48);
				SetPal(159,36,36,36);
				SetPal(160,252,196,16);
				SetPal(161,240,176,16);
				SetPal(162,220,160,12);
				SetPal(163,204,144,12);
				SetPal(164,184,128,12);
				SetPal(165,168,112,12);
				SetPal(166,156,100,12);
				SetPal(167,140,88,12);
				SetPal(168,128,76,12);
				SetPal(169,112,64,12);
				SetPal(170,100,56,12);
				SetPal(171,88,48,12);
				SetPal(172,72,36,12);
				SetPal(173,60,32,12);
				SetPal(174,52,24,12);
				SetPal(175,36,20,12);
				SetPal(176,252,92,92);
				SetPal(177,240,76,72);
				SetPal(178,228,64,64);
				SetPal(179,212,56,52);
				SetPal(180,196,48,40);
				SetPal(181,180,36,32);
				SetPal(182,168,32,24);
				SetPal(183,156,28,20);
				SetPal(184,140,24,16);
				SetPal(185,128,20,16);
				SetPal(186,112,16,16);
				SetPal(187,100,16,12);
				SetPal(188,88,12,12);
				SetPal(189,72,12,12);
				SetPal(190,64,12,12);
				SetPal(191,52,12,12);
				SetPal(192,136,192,252);
				SetPal(193,120,172,244);
				SetPal(194,104,160,232);
				SetPal(195,92,140,216);
				SetPal(196,84,128,204);
				SetPal(197,68,108,192);
				SetPal(198,60,100,176);
				SetPal(199,48,88,164);
				SetPal(200,36,72,148);
				SetPal(201,32,60,136);
				SetPal(202,24,52,124);
				SetPal(203,20,40,108);
				SetPal(204,16,32,96);
				SetPal(205,12,24,84);
				SetPal(206,12,20,72);
				SetPal(207,12,16,60);
				SetPal(208,164,252,160);
				SetPal(209,140,240,132);
				SetPal(210,120,220,104);
				SetPal(211,100,204,84);
				SetPal(212,88,184,64);
				SetPal(213,72,168,48);
				SetPal(214,64,148,32);
				SetPal(215,60,136,28);
				SetPal(216,56,124,20);
				SetPal(217,52,108,20);
				SetPal(218,48,100,16);
				SetPal(219,40,88,16);
				SetPal(220,36,72,12);
				SetPal(221,32,60,12);
				SetPal(222,28,48,12);
				SetPal(223,24,36,12);
				SetPal(224,252,172,120);
				SetPal(225,240,156,100);
				SetPal(226,220,140,84);
				SetPal(227,204,124,64);
				SetPal(228,184,108,52);
				SetPal(229,168,96,36);
				SetPal(230,148,88,28);
				SetPal(231,136,76,24);
				SetPal(232,124,68,20);
				SetPal(233,108,64,16);
				SetPal(234,100,56,16);
				SetPal(235,88,52,12);
				SetPal(236,72,40,12);
				SetPal(237,60,36,12);
				SetPal(238,48,28,12);
				SetPal(239,36,24,12);
				SetPal(240,232,232,232);
				SetPal(241,0,0,0);
				SetPal(242,24,4,4);
				SetPal(243,8,12,36);
				SetPal(244,4,8,24);
				SetPal(245,12,24,28);
				SetPal(246,24,24,8);
				SetPal(247,24,24,24);
				SetPal(248,36,48,52);
				SetPal(249,8,12,48);
				SetPal(250,0,0,0);
				SetPal(251,100,88,168);
				SetPal(252,112,28,64);
				SetPal(253,12,252,12);
				SetPal(254,0,0,0);
				SetPal(255,104,104,120);
		}

		/// <summary>
		/// Cycles the palette.
		/// </summary>
		/// <param name="start">Start index to cycle</param>
		/// <param name="end">End index to cycle</param>
		void CyclePalette(int start, int end)
		{
				for (int i=end; i>=start;i--)
				{
						if (i ==start)
						{
								UpdatePal(start,red[end],green[end],blue[end]);
						}
						else
						{
								UpdatePal(i,red[i-1],red[i-1],blue[i-1]);
						}

				}
		}


		void UpdateAnimation()
		{
			CyclePalette(16,22);//fire
			CyclePalette(48,51);//water?
		}

		/// <summary>
		/// Applies the cycled palette to a greyscale image
		/// </summary>
		/// <returns>The palette.</returns>
		/// <param name="SrcImage">Source image.</param>
		public Texture2D ApplyPalette(Texture2D SrcImage)
		{
				int ColourIndex;
				Texture2D DstImage=new Texture2D(SrcImage.width, SrcImage.height ,SrcImage.format, false);
				for (int i =0; i<=SrcImage.width;i++)
				{
						for (int j =0; j<=SrcImage.height;j++)
						{
								ColourIndex = (int)(SrcImage.GetPixel(i,j).r * 255f);
								DstImage.SetPixel(i,j,GetPal (ColourIndex));
						}
				}
				DstImage.Apply();

				return DstImage;
		}

		/// <summary>
		/// Applies the default palette to a greyscale image.
		/// </summary>
		/// <returns>The palette default.</returns>
		/// <param name="SrcImage">Source image.</param>
		public Texture2D ApplyPaletteDefault(Texture2D SrcImage)
		{
				Texture2D DstImage=new Texture2D(SrcImage.width, SrcImage.height ,SrcImage.format, false);
				int ColourIndex;
				for (int i =0; i<=SrcImage.width;i++)
				{
						for (int j =0; j<=SrcImage.height;j++)
						{
								ColourIndex = (int)(SrcImage.GetPixel(i,j).r * 255f);
								DstImage.SetPixel(i,j,GetPalDef (ColourIndex));
						}
				}
				DstImage.Apply();

				return DstImage;
		}

		/// <summary>
		/// Sets the palette values
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="Red">Red.</param>
		/// <param name="Green">Green.</param>
		/// <param name="Blue">Blue.</param>
		void SetPal(int index, float Red, float Green, float Blue)
		{
				red[index]=(float)Red/255.0f;
				green[index]=(float)Green/255.0f;
				blue[index]=(float)Blue/255.0f;

				Defred[index]=(float)Red/255.0f;
				Defgreen[index]=(float)Green/255.0f;
				Defblue[index]=(float)Blue/255.0f;
		}

		/// <summary>
		/// Updates the palette values
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="Red">Red.</param>
		/// <param name="Green">Green.</param>
		/// <param name="Blue">Blue.</param>
		void UpdatePal(int index, float Red, float Green, float Blue)
		{
				red[index]=Red;
				green[index]=Green;
				blue[index]=Blue;
		}


		/// <summary>
		/// Gets the color at the specified index of the cycled palette.
		/// </summary>
		/// <returns>The pal.</returns>
		/// <param name="index">Index.</param>
		Color GetPal(int index)
		{   
				if (index !=0)
				{
						return new Color(red[index],green[index],blue[index]);
				}
				else
				{
						return Color.clear;
				}
		}


		/// <summary>
		/// Gets the color at the index of the default palette.
		/// </summary>
		/// <returns>The pal def.</returns>
		/// <param name="index">Index.</param>
		Color GetPalDef(int index)
		{  
				if (index !=0)
				{
						return new Color(Defred[index],Defgreen[index],Defblue[index]);
				}
				else
				{
						return Color.clear;
				}

		}
}