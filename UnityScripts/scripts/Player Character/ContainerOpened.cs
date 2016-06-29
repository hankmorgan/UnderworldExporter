using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContainerOpened : object_base {
//The gui element that represents the currently opened container in the inventory.

	void CloseChildContainer(Container ClosingParent)
	{//Recursively closes open child containers
		ClosingParent.isOpenOnPanel=false;
		for (int i = 0;i<ClosingParent.MaxCapacity();i++)
		{
			if (ClosingParent.items[i] !="")
			{
				GameObject currObj = GameObject.Find (ClosingParent.items[i]);
				{
					if (currObj!=null)
					{
						Container currObjContainer = currObj.GetComponent<Container>();
						if (currObjContainer !=null)
						{
							CloseChildContainer (currObjContainer);
						}
					}
				}
			}
		}
	}

	public void OnClick()
	{
		if (playerUW.playerInventory.currentContainer==playerUW.name)
		{//Don't do anything on the top level
			playerUW.playerInventory.ContainerOffset=0;
			return;
		}
		if (playerUW.playerInventory.ObjectInHand=="")
		{//Player has no object in their hand. We close up the container.
			ScrollButtonInventory.ScrollValue=0;
			playerUW.playerInventory.ContainerOffset=0;
			Container currentContainerObj = playerUW.playerInventory.GetCurrentContainer();
			playerUW.playerInventory.currentContainer = currentContainerObj.ContainerParent;
			currentContainerObj.isOpenOnPanel=false;
			//Close child containers as well
			CloseChildContainer (currentContainerObj);
			Container DestinationContainer = playerUW.playerInventory.GetCurrentContainer();
			if (playerUW.playerInventory.currentContainer == GameWorldController.instance.playerUW.name)
			{
				GetComponent<RawImage>().texture=playerUW.playerInventory.Blank;
			}
			else
			{
				GetComponent<RawImage>().texture=DestinationContainer.transform.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
			}
			for (int i = 0; i<8; i++)
			{
				string sItem = DestinationContainer.GetItemAt(i);
				playerUW.playerInventory.SetObjectAtSlot(i+11,sItem);
			}
		}
		else
		{
			if (UWCharacter.InteractionMode!=UWCharacter.InteractionModePickup)
			{//Only allow this to happen when in pickup mode.
				return;
			}
			//Move the contents out of the container into the parent.
			Container CurrentContainer = GameObject.Find (playerUW.playerInventory.currentContainer).GetComponent<Container>();
			Container DestinationContainer = GameObject.Find (CurrentContainer.ContainerParent).GetComponent<Container>();
			ObjectInteraction item = GameObject.Find (playerUW.playerInventory.ObjectInHand).GetComponent<ObjectInteraction>();
			if (Container.TestContainerRules(DestinationContainer,11))
			{
				//if ((item.isQuant==false) || (item.isEnchanted))
				if (item.IsStackable())
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
}
