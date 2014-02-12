using UnityEngine;
using System.Collections;

public class PlayerControls
{
	public enum ControlType {Keyboard1, Keyboard2, Controller};

	//Storing keys/buttons as strings due to 360 controller support lacking an equivalent to KeyCode
	private string keyMoveLeft = "";
	private string keyMoveRight = "";
	private string keyPunch = "";
	private string keyBlock = "";

	//Constructor
	public PlayerControls (ControlType playerControls) 
	{
		switch(playerControls)
		{
			case ControlType.Keyboard1:
				keyMoveLeft = "A";
				keyMoveRight = "D";
        		keyPunch = "F";
        		keyBlock = "G";
				break;
			case ControlType.Keyboard2:
				keyMoveLeft = "LeftArrow";
				keyMoveRight = "RightArrow";
				keyPunch = "4";
				keyBlock = "6";
				break;
			case ControlType.Controller:
				keyMoveLeft = "";
				keyMoveRight = "";
				keyPunch = "A";
				keyBlock = "B";
				break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
