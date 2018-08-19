using UnityEngine;
using System.Collections;

public class Sign : Decal {
	//private bool spriteReady;
	protected override void Start ()
	{
		base.Start ();
		BoxCollider bx = this.GetComponent<BoxCollider>();
		bx.size= new Vector3(0.3f, 0.3f, 0.1f);
		bx.center= new Vector3(0.0f,0.15f,0.0f);
		//setSprite(this.GetComponentInChildren<SpriteRenderer>(),_RES + "/Sprites/tmobj/tmobj_" + (20 + (flags & 0x07)));
		setSpriteTMOBJ(this.GetComponentInChildren<SpriteRenderer>(),(20 + (flags & 0x07)));
	}


	public override bool use ()
	{
		return Read();
	}

	public override bool LookAt ()
	{
		return Read ();
	}

	public virtual bool Read ()
	{
		switch (_RES)
		{

		case GAME_UW2:
			{
				//TODO: Need to figure out how the "sign/writing/plaque" etc prefix works
				if (isquant==1)
				{//This is a normal sign
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (8,link - 0x200));
						return true;		
				}
				else
				{//This is linked to a trigger that spouts some nonsense.
					ObjectInteraction linkObj = ObjectLoader.getObjectIntAt(link);
					if (linkObj!=null)
					{
						switch (linkObj.GetItemType())
						{
						case ObjectInteraction.A_USE_TRIGGER:
							return linkObj.GetComponent<trigger_base>().Activate(this.gameObject);					
						case ObjectInteraction.A_LOOK_TRIGGER:
							return linkObj.GetComponent<trigger_base>().Activate(this.gameObject);
						default:
							UWHUD.instance.MessageScroll.Add("You need to investigate me " + this.name);
							return true;
						}

					}
				}
				return false;
			}
		default:
			{
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (8,link - 0x200));
				return true;								
			}

		}
		
	}


	public override string UseVerb()
	{
			return "read";	
	}

	public override string ExamineVerb ()
	{
			return "read";
	}


}
