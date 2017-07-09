using UnityEngine;
using System.Collections;

/// <summary>
/// Used to associate map note ui elements with the Map note information
/// </summary>
public class MapNoteId : MonoBehaviour{
	
		public System.Guid guid;

		public void OnClick()
		{
				if (MapInteraction.InteractionMode == 1)
				{
						//delete the mapnote
						for (int i =0; i< GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes.Count;i++)
						{
								if (guid== GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes[i].guid)
								{
										GameWorldController.instance.AutoMaps[MapInteraction.MapNo].MapNotes.RemoveAt(i);
										Destroy(this.gameObject);						
										return;								
								}
						}

				}

		}
}
