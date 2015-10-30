using UnityEngine;
using System.Collections;

public class ContainerOpened : object_base {

	//public string ContainerTarget; //What container those this widget point back to. blank for player inventory. only matters for the slots
	// Use this for initialization

	void CloseChildContainer(Container ClosingParent)
	{//Recursively closes open child containers
		ClosingParent.isOpenOnPanel=false;
		for (int i = 0;i<40;i++)
		{
			if (ClosingParent.items[i] !="")
			{
				GameObject currObj = GameObject.Find (ClosingParent.items[i]);
				{
					if (currObj!=null)
					{
						Container currObjContainer = currObj.GetComponent<Container>();
						//Debug.Log ("closing " + currObj.name);
						if (currObjContainer !=null)
						{
							CloseChildContainer (currObjContainer);
						}
					}
					else
					{
						//Debug.Log (">" + ClosingParent.items[i] + "< is null!)");
					}
				}
			}
		}
	}

	void OnClick()
	{
		//UWCharacter playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		//PlayerInventory pInv = GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		if (playerUW.playerInventory.currentContainer==playerUW.name)
		{//Don't do anything on the top level
			playerUW.playerInventory.ContainerOffset=0;
			return;
		}
		if (playerUW.playerInventory.ObjectInHand=="")
		{//Player has no object in their hand. We close up the container.
			ScrollButtonInventory.ScrollValue=0;
			playerUW.playerInventory.ContainerOffset=0;
			Container currentContainerObj = playerUW.playerInventory.GetCurrentContainer();//GameObject.Find (pInv.currentContainer).GetComponent<Container>();
			playerUW.playerInventory.currentContainer = currentContainerObj.ContainerParent;
			currentContainerObj.isOpenOnPanel=false;
			//Close child containers as well
			CloseChildContainer (currentContainerObj);
			//Debug.Log("Current Container is " + pInv.currentContainer);
			Container DestinationContainer = playerUW.playerInventory.GetCurrentContainer();// GameObject.Find (pInv.currentContainer).GetComponent<Container>();
			if (playerUW.playerInventory.currentContainer == "Gronk")
			{
				//GetComponent<UISprite>().spriteName="object_blank";
				GetComponent<UITexture>().mainTexture=playerUW.playerInventory.Blank;
			}
			else
			{
				//GetComponent<UISprite>().spriteName=DestinationContainer.transform.GetComponent<ObjectInteraction>().InventoryString;
				GetComponent<UITexture>().mainTexture=DestinationContainer.transform.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
			}
			for (int i = 0; i<8; i++)
			{
				string sItem = DestinationContainer.GetItemAt(i);
				playerUW.playerInventory.SetObjectAtSlot(i+11,sItem);
			}
		}
		else
		{
			//Move the contents out of the container into the parent.
			//Debug.Log ("Moving contents out of bag");
			Container CurrentContainer = GameObject.Find (playerUW.playerInventory.currentContainer).GetComponent<Container>();
			Container DestinationContainer = GameObject.Find (CurrentContainer.ContainerParent).GetComponent<Container>();
			ObjectInteraction item = GameObject.Find (playerUW.playerInventory.ObjectInHand).GetComponent<ObjectInteraction>();
			if ((item.isQuant==false) || (item.isEnchanted))
			{
				if (DestinationContainer.AddItemToContainer(playerUW.playerInventory.ObjectInHand))
				{//Object has moved
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					playerUW.playerInventory.ObjectInHand="";
				}
			}
			else
			{
				if (DestinationContainer.AddItemMergedItemToContainer(item.gameObject))
				{//Object has moved
					playerUW.CursorIcon= playerUW.CursorIconDefault;
					playerUW.playerInventory.ObjectInHand="";
				}
			}
		}
	}
}
