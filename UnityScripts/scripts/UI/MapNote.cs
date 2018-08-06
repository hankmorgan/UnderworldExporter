using UnityEngine;
using System.Collections;
/// <summary>
/// Map note. Storage for map notes
/// </summary>
public class MapNote : UWClass {
		//public Vector2 NotePosition;
		public string NoteText;
		public System.Guid guid;
		public int PosX;
		public int PosY;

        public MapNote(int posX, int posY, string noteText)
        {
            PosX = posX;
            PosY = posY;
            NoteText = noteText;
            guid = System.Guid.NewGuid();
        }

		public Vector2 NotePosition()
		{
			return new Vector2((float)PosX,(float)PosY-100f);
		}

}
