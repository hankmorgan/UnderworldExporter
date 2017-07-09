using UnityEngine;
using System.Collections;
/// <summary>
/// Map note. Storage for map notes
/// </summary>
public class MapNote {
		//public Vector2 NotePosition;
		public string NoteText;
		public System.Guid guid;
		public int PosX;
		public int PosY;

		public Vector2 NotePosition()
		{
			return new Vector2((float)PosX,(float)PosY-100f);
		}

}
