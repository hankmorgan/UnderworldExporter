using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputHandler : GuiBase {

		public const int  InputCharacterQty = 0;
		public const int  InputInventoryQty = 1;
		public const int  InputConversationWords = 2;
		public const int  InputMantraWords = 3;
		public const int  InputAnvil = 4;

		//For passing typed input to various objects

		public GameObject target;
		public int currentInputMode;

		public void OnSubmit()
		{
				if (target==null)
				{return;}
				int valueInt=0;
				string valueStr="";
				switch (currentInputMode)
				{
				case InputCharacterQty:
				case InputInventoryQty:
						valueInt=ParseInteger();
						break;
				case InputConversationWords:
				case InputMantraWords:
				case InputAnvil:
						valueStr=ParseString();
						break;
				}

				switch (currentInputMode)
				{
				case InputCharacterQty:
						target.gameObject.GetComponent<UWCharacter>().OnSubmitPickup(valueInt);
						break;
				case InputInventoryQty:
						target.gameObject.GetComponent<InventorySlot>().OnSubmitPickup(valueInt);
						break;		
				case InputConversationWords:
						target.gameObject.GetComponent<Conversation>().OnSubmitPickup(valueStr);
						break;
				case InputMantraWords:
						target.gameObject.GetComponent<Shrine>().OnSubmitPickup(valueStr);
						break;
				case InputAnvil:
						target.gameObject.GetComponent<Equipment>().OnSubmitPickup(valueStr);
						break;
				}

		}


		public int ParseInteger()
		{
				InputField inputctrl =GameWorldController.instance.playerUW.playerHud.InputControl;
				//Debug.Log (inputctrl.text);
				int quant=0;
				if (int.TryParse(inputctrl.text,out quant)==false)
				{
						return 0;
				}
				else
				{
						return quant;		
				}
		}

		public string ParseString()
		{
				InputField inputctrl =GameWorldController.instance.playerUW.playerHud.InputControl;
				return inputctrl.text;
		}

}
