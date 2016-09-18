using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Click buttons
/// </summary>
public class OptionsMenuButton : MonoBehaviour {

		public enum OptionsMenu
		{
				SAVE = 0,
				SAVE_SLOT_0=1,
				SAVE_SLOT_1=2,
				SAVE_SLOT_2=3,
				SAVE_SLOT_3=4,
				SAVE_SLOT_CANCEL=5,
				RESTORE = 6,
				RESTORE_SLOT_0=7,
				RESTORE_SLOT_1=8,
				RESTORE_SLOT_2=9,
				RESTORE_SLOT_3=10,
				RESTORE_SLOT_CANCEL=11,
				MUSIC = 12,
				MUSIC_ON = 13,
				MUSIC_OFF = 14,
				MUSIC_CANCEL = 15,
				SOUND = 16,
				SOUND_ON = 17,
				SOUND_OFF = 18,
				SOUND_CANCEL = 19,
				DETAIL = 20,
				DETAIL_LOW = 21,
				DETAIL_MED = 22,
				DETAIL_HI = 23,
				DETAIL_BEST = 24,
				DETAIL_DONE = 25,
				RETURN = 26,
				QUIT = 27,
				QUIT_YES = 28,
				QUIT_NO = 29,
		}

		public Texture2D ButtonOff;
		public Texture2D ButtonOn;
		public RawImage ButtonBG;

		public OptionsMenuControl SubmitTarget;

		public OptionsMenu index; //List in OptionsMenuControl

		public void OnHoverEnter()
		{
			ButtonBG.texture=ButtonOn;
		}

		public void OnHoverExit()
		{
			ButtonBG.texture=ButtonOff;
		}


		public virtual void OnClick()
		{
			SubmitTarget.ButtonClickOptionsMenu((int)index);
		}

}
