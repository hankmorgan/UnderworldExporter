using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent (typeof (CharacterMotorC))]

//RequireComponent (CharacterMotor)
[AddComponentMenu("Character/FPS Input Controller C")]
//@script AddComponentMenu ("Character/FPS Input Controller")


public class FPSInputControllerC : MonoBehaviour {
    private CharacterMotorC cmotor;
    // Use this for initialization
    void Awake() {
        cmotor = GetComponent<CharacterMotorC>();
    }

    // Update is called once per frame
    void Update () {
        // Get the input vector from keyboard or analog stick
        Vector3 directionVector;
        directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (directionVector != Vector3.zero) {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }

        // Apply the direction to the CharacterMotor
        cmotor.inputMoveDirection = transform.rotation * directionVector;
        cmotor.inputJump = Input.GetButton("Jump");
    }

}