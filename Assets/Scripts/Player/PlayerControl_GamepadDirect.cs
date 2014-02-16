using UnityEngine;
using System.Collections;

public class PlayerControl_GamepadDirect : MonoBehaviour {

	public Transform rightUpperArm;
	public Transform rightLowerArm;
	public Transform rightHand;

	public Transform leftUpperArm;
	public Transform leftLowerArm;
	public Transform leftHand;

	private Quaternion rightUpperArmBaseRotation;
	private Quaternion rightLowerArmBaseRotation;
	private Quaternion rightHandBaseRotation;
	private float rightUpperArmLocalRotation = 0.0f;
	private float rightLowerArmLocalRotation = 0.0f;
	private float rightHandLocalRotation = 0.0f;
	private float rightUpperArmLocalRotationMax = 45.0f;
	private float rightLowerArmLocalRotationMax = -35.0f;
	private float rightHandLocalRotationMax = -30.0f;
	private float rightUpperArmLocalRotationBlockMax = -35.0f;
	private float rightLowerArmLocalRotationBlockMax = -35.0f;
	private float rightHandLocalRotationBlockMax = -35.0f;

	private Quaternion leftUpperArmBaseRotation;
	private Quaternion leftLowerArmBaseRotation;
	private Quaternion leftHandBaseRotation;
	private float leftUpperArmLocalRotation = 0.0f;
	private float leftLowerArmLocalRotation = 0.0f;
	private float leftHandLocalRotation = 0.0f;
	private float leftUpperArmLocalRotationMax = 45.0f;
	private float leftLowerArmLocalRotationMax = -35.0f;
	private float leftHandLocalRotationMax = 10.0f;
	private float leftUpperArmLocalRotationBlockMax = -35.0f;
	private float leftLowerArmLocalRotationBlockMax = -35.0f;
	private float leftHandLocalRotationBlockMax = -35.0f;


	// Use this for initialization
	void Start () 
	{
		rightUpperArmBaseRotation = rightUpperArm.rotation;
		rightLowerArmBaseRotation = rightLowerArm.rotation;
		rightHandBaseRotation = rightHand.rotation;

		leftUpperArmBaseRotation = leftUpperArm.rotation;
		leftLowerArmBaseRotation = leftLowerArm.rotation;
		leftHandBaseRotation = leftHand.rotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//-- apply input
		float lsY = -Input.GetAxis(GAMEPAD.AXIS[0].LS_Y);
		float rsY = -Input.GetAxis(GAMEPAD.AXIS[0].RS_Y);
		if(lsY >= 0)
		{
			//-- punching
			leftUpperArmLocalRotation = lsY * leftUpperArmLocalRotationMax;
			leftLowerArmLocalRotation = lsY * leftLowerArmLocalRotationMax;
			leftHandLocalRotation = lsY * leftHandLocalRotationMax;
		}
		else
		{
			//-- blocking
			leftUpperArmLocalRotation = lsY * leftUpperArmLocalRotationBlockMax;
			leftLowerArmLocalRotation = lsY * leftLowerArmLocalRotationBlockMax;
			leftHandLocalRotation = lsY * leftHandLocalRotationBlockMax;
		}

		if(rsY >= 0)
		{
			//-- punching
			rightUpperArmLocalRotation = rsY * rightUpperArmLocalRotationMax;
			rightLowerArmLocalRotation = rsY * rightLowerArmLocalRotationMax;
			rightHandLocalRotation = rsY * rightHandLocalRotationMax;
		}
		else
		{
			//-- blocking
			rightUpperArmLocalRotation = rsY * rightUpperArmLocalRotationBlockMax;
			rightLowerArmLocalRotation = rsY * rightLowerArmLocalRotationBlockMax;
			rightHandLocalRotation = rsY * rightHandLocalRotationBlockMax;
		}




		//-- combine local rotations with base rotations
		rightUpperArm.rotation = rightUpperArmBaseRotation;
		rightUpperArm.Rotate(Vector3.forward, rightUpperArmLocalRotation);
		rightLowerArm.rotation = rightLowerArmBaseRotation;
		rightLowerArm.Rotate(Vector3.forward, rightLowerArmLocalRotation);
		rightHand.rotation = rightHandBaseRotation;
		rightHand.Rotate(Vector3.forward, rightHandLocalRotation);

		leftUpperArm.rotation = leftUpperArmBaseRotation;
		leftUpperArm.Rotate(Vector3.forward, leftUpperArmLocalRotation);
		leftLowerArm.rotation = leftLowerArmBaseRotation;
		leftLowerArm.Rotate(Vector3.forward, leftLowerArmLocalRotation);
		leftHand.rotation = leftHandBaseRotation;
		leftHand.Rotate(Vector3.forward, leftHandLocalRotation);
	}
}
