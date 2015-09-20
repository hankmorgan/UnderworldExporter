using UnityEngine;
using System.Collections;

public class ContainerOpened : MonoBehaviour {

	//public string ContainerTarget; //What container those this widget point back to. blank for player inventory. only matters for the slots
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CloseChildContainer(Container ClosingParent)
	{//Recursively closes open child containers
		ClosingParent.isOpenOnPanel=false;
		for (int i = 0;i<40;i++)
		{
			if (ClosingParent.items[i] !="")
			{
				GameObject currObj = GameObject.Find (ClosingParent.items[i]);
				{
					//Debug.Log ("closing " + currObj.name);
					if (currObj.GetComponent<ObjectInteraction>().isContainer ==true)
					{
						CloseChildContainer (currObj.GetComponent<Container>());
					}
				}
			}
		}
	}

	void OnClick()
	{
		UWCharacter playerUW=GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		PlayerInventory pInv = GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		if (pInv.currentContainer=="Gronk")
		{//Don't do anything on the top level
			return;
		}
		if (pInv.ObjectInHand=="")
		{//Player has no object in their hand. We close up the container.
			Container currentContainerObj = GameObject.Find (pInv.currentContainer).GetComponent<Container>();
			pInv.currentContainer = currentContainerObj.ContainerParent;
			currentContainerObj.isOpenOnPanel=false;
			//Close child containers as well
			CloseChildContainer (currentContainerObj);
			Debug.Log("Current Container is " + pInv.currentContainer);
			Container DestinationContainer = GameObject.Find (pInv.currentContainer).GetComponent<Container>();
			if (pInv.currentContainer == "Gronk")
			{
				//GetComponent<UISprite>().spriteName="object_blank";
				GetComponent<UITexture>().mainTexture=pInv.Blank;
			}
			else
			{
				//GetComponent<UISprite>().spriteName=DestinationContainer.transform.GetComponent<ObjectInteraction>().InventoryString;
				GetComponent<UITexture>().mainTexture=DestinationContainer.transform.GetComponent<ObjectInteraction>().InventoryDisplay.texture;
			}
			for (int i = 0; i<8; i++)
			{
				string sItem = DestinationContainer.GetItemAt(i);
				pInv.SetObjectAtSlot(i+11,sItem);
			}
		}
		else
		{
			//Move the contents out of the container into the parent.
			//Debug.Log ("Moving contents out of bag");
			Container CurrentContainer = GameObject.Find (pInv.currentContainer).GetComponent<Container>();
			Container DestinationContainer = GameObject.Find (CurrentContainer.ContainerParent).GetComponent<Container>();
			if (DestinationContainer.AddItemToContainer(pInv.ObjectInHand))
			{//Object has moved
				//UWCharacter playerUW = player.GetComponent<UWCharacter>();
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.CurrObjectSprite = "";
				pInv.ObjectInHand="";
			}
		}
	}
}
