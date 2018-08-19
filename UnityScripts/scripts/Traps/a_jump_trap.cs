using UnityEngine;
using System.Collections;

public class a_jump_trap : trap_base
{
    //based on https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html

    //The quality of the trap controls the strength of the jump trap.

    Vector3 impact = Vector3.zero;
    const float mass = 3f;
    public float force = 60f;
    public float Timer;
    public CharacterController current;

    protected override void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("NPCTraps");
        base.Start();
        BoxCollider bx = this.GetComponent<BoxCollider>();
        if (bx != null)
        {
            bx.center = new Vector3(0.6f, 0.08f, 0.6f);
            bx.size = new Vector3(1.2f, 0.4f, 1.2f);
            bx.isTrigger = true;
        }
    }


    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        if (Timer <= 0)
        {
            if (current==null)
            {
                ExecuteJumpOnController(UWCharacter.Instance.transform);
            }            
        }
    }

    private void ExecuteJumpOnController(Transform t)
    {
        current = t.gameObject.GetComponent<CharacterController>();
        Timer = 2f;
        //Try and launch the character in their direction of motion and upwards.
        AddImpact((2 * t.forward) + (5 * Vector3.up), quality * 2f);
    }

    // call this function to add an impact force:
    void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }


    public override void Update()
    {
        ApplyToController();
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = 0;
            }
        }
    }

    private void ApplyToController()
    {
        // apply the impact force:
        if ((impact.magnitude > 0.2) && (current!=null))
        {
            current.Move(impact * Time.deltaTime);
        }
        else
        {
            current = null;
        }
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

    public override void PostActivate(object_base src)
    {//do not delete

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (current==null)
        {
            ExecuteJumpOnController(other.transform);
        }
    }
}
