using UnityEngine;
using System.Collections;
using System.Linq;

public class LargeBlackrockGem : Model3D {

    private void Awake()
    {
        a_hack_trap_gemrotate.gem = this;
    }

    protected override void Start()
    {
        base.Start();

        //Initialise the gem face
        for (int i = 0; i <= 7; i++)
        {
            if (i == Quest.instance.variables[6])
            {
                this.GetComponent<MeshRenderer>().materials[i].SetColor("_Color", Color.white);
            }
            else
            {
                this.GetComponent<MeshRenderer>().materials[i].SetColor("_Color", Color.blue);
            }
        }
    }

    public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand!="")
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
		else
		{
			return base.use();
		}
	}

	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objI=ObjectUsed.GetComponent<ObjectInteraction>();
		if (objI!=null)
		{
			if (objI.GetItemType()==ObjectInteraction.A_BLACKROCK_GEM)
			{
				if (objI.owner==1)
				{	
					int thisGemIndex= objI.item_id-280;
					int bitField = (1<<thisGemIndex);
					Quest.instance.x_clocks[2]++;
					Quest.instance.QuestVariables[130] |= bitField;
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,338));				
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,338+Quest.instance.x_clocks[2]));
                    //CameraShake.instance.shakeDuration = Quest.instance.x_clocks[2] * 0.2f;
                    CameraShake.instance.ShakeEarthQuake(Quest.instance.x_clocks[2] * 0.2f);
                    objI.consumeObject(); 
                }
				else
				{
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,347));
				}				
				UWCharacter.Instance.playerInventory.ObjectInHand="";
				return true;
			}
		}
		return false;
	}


	public override Vector3[] ModelVertices ()
	{
		Vector3[] ModelVerts=new Vector3[48];
		ModelVerts[0] = new Vector3(-0.0703125f,0.3554688f,0f);
		ModelVerts[1] = new Vector3(-0.1484375f,0.2773438f,-0.1679688f);
		ModelVerts[2] = new Vector3(-0.1289063f,0f,-0.3164063f);
		ModelVerts[3] = new Vector3(-0.04296875f,0.3554688f,-0.0625f);
		ModelVerts[4] = new Vector3(-0.3242188f,0.08203125f,0f);
		ModelVerts[5] = new Vector3(-0.21875f,0.2773438f,0f);
		ModelVerts[6] = new Vector3(0.00390625f,0.3554688f,-0.08984375f);
		ModelVerts[7] = new Vector3(0.00390625f,0.08203125f,-0.328125f);
		ModelVerts[8] = new Vector3(0.00390625f,0.2773438f,-0.2382813f);
		ModelVerts[9] = new Vector3(-0.2265625f,0.08203125f,-0.234375f);
		ModelVerts[10] = new Vector3(-0.3085938f,0f,-0.1445313f);
		ModelVerts[11] = new Vector3(-0.3359375f,0f,-0.3476563f);
		ModelVerts[12] = new Vector3(0.234375f,0.08203125f,-0.234375f);
		ModelVerts[13] = new Vector3(0.1367188f,0f,-0.3164063f);
		ModelVerts[14] = new Vector3(0.34375f,0f,-0.3476563f);
		ModelVerts[15] = new Vector3(0.3164063f,0f,-0.1445313f);
		ModelVerts[16] = new Vector3(0.3320313f,0.08203125f,0f);
		ModelVerts[17] = new Vector3(0.2265625f,0.2773438f,0f);
		ModelVerts[18] = new Vector3(0.15625f,0.2773438f,-0.1679688f);
		ModelVerts[19] = new Vector3(0.05078125f,0.3554688f,-0.0625f);
		ModelVerts[20] = new Vector3(0.078125f,0.3554688f,0f);
		ModelVerts[21] = new Vector3(0.00390625f,0f,-0.734375f);
		ModelVerts[22] = new Vector3(0.00390625f,0.08203125f,0.328125f);
		ModelVerts[23] = new Vector3(0.1367188f,0f,0.3164063f);
		ModelVerts[24] = new Vector3(0.00390625f,0f,0.734375f);
		ModelVerts[25] = new Vector3(-0.1289063f,0f,0.3164063f);
		ModelVerts[26] = new Vector3(0.34375f,0f,0.3476563f);
		ModelVerts[27] = new Vector3(0.234375f,0.08203125f,0.234375f);
		ModelVerts[28] = new Vector3(-0.2265625f,0.08203125f,0.234375f);
		ModelVerts[29] = new Vector3(-0.3359375f,0f,0.3476563f);
		ModelVerts[30] = new Vector3(0.3164063f,0f,0.1445313f);
		ModelVerts[31] = new Vector3(-0.3085938f,0f,0.1445313f);
		ModelVerts[32] = new Vector3(0.15625f,0.2773438f,0.1679688f);
		ModelVerts[33] = new Vector3(-0.1484375f,0.2773438f,0.1679688f);
		ModelVerts[34] = new Vector3(0.00390625f,0.2773438f,0.2382813f);
		ModelVerts[35] = new Vector3(0.05078125f,0.3554688f,0.0625f);
		ModelVerts[36] = new Vector3(-0.04296875f,0.3554688f,0.0625f);
		ModelVerts[37] = new Vector3(0.00390625f,0.3554688f,0.08984375f);
		ModelVerts[38] = new Vector3(-0.640625f,0f,0f);
		ModelVerts[39] = new Vector3(0.6367188f,0f,0f);
		ModelVerts[40] = new Vector3(-0.3203125f,0f,-0.234375f);
		ModelVerts[41] = new Vector3(0.109375f,0f,-0.40625f);
		ModelVerts[42] = new Vector3(-0.4101563f,0f,0.1015625f);
		ModelVerts[43] = new Vector3(0.328125f,0f,0.234375f);
		ModelVerts[44] = new Vector3(-0.1015625f,0f,0.40625f);
		ModelVerts[45] = new Vector3(-0.3203125f,0f,0.2265625f);
		ModelVerts[46] = new Vector3(0.328125f,0f,-0.2265625f);
		ModelVerts[47] = new Vector3(0.4179688f,0f,0.09765625f);
		return ModelVerts;
	}

	public override int[] ModelTriangles (int meshNo)
	{
		switch (meshNo)
		{
			case 0: //Prison tower face
				return new int[]{17,27,32,17,30,27,17,16,30}.Reverse().ToArray();
			case 1: //Kilhorn face
				return new int[]{18,16,17,18,15,16,18,12,15}.Reverse().ToArray();	
			case 2: 
				return new int[]{8,12,18,8,13,12,8,7,13}.Reverse().ToArray();
			case 3: //Talorus face					
				return new int[]{1,7,8,1,2,7,1,9,2}.Reverse().ToArray();
			case 4: //academy
				return new int[]{1,10,9,1,5,10,5,4,10}.Reverse().ToArray();
			case 5: //Pits
				return new int[]{33,4,5,33,31,4,33,28,31}.Reverse().ToArray();
			case 6: //Tomb
				return new int[]{34,28,33,34,25,28,34,22,25}.Reverse().ToArray();
			case 7: //Void
				return new int[]{32,22,34,32,23,22,32,27,23}.Reverse().ToArray();
			case 8: // base + cap
				return new int[]{24,25,22,24,22,23,26,23,27,26,27,30,39,30,16,39,16,15,14,15,12,14,12,13,13,7,21,7,2,21,2,9,11,9,10,11,10,4,38,4,31,38,31,28,29,29,28,25,0,1,3,0,5,1,0,33,5,0,36,33,33,36,37,37,34,33,37,32,34,37,35,32,32,35,20,32,20,17,17,20,18,18,19,8,8,19,6,8,6,3,8,3,1,18,20,19,0,3,6,0,6,19,0,19,20,0,20,35,0,35,37,0,37,36}.Reverse().ToArray();									
		}
		return base.ModelTriangles(meshNo);
	}


	public override int NoOfMeshes ()
	{
			return 9;
	}


	public override Color ModelColour (int meshNo)
	{
		switch (meshNo)
		{
		case 8: 
			return Color.magenta;
		default:
			return Color.blue;
		}
	}

		/*
1,10,9,1,5,10,5,4,10			// academy
1,7,8,1,2,7,1,9,2				// Talorus
8,12,18,8,13,12,8,7,13          // ice?
18,16,17,18,15,16,18,12,15		//kilhorn
17,27,32,17,30,27,17,16,30		// Prison tower
32,22,34,32,23,22,32,27,23		//Void
34,28,33,34,25,28,34,22,25		//Tomb
33,4,5,33,31,4,33,28,31			//Pits
*/
}
