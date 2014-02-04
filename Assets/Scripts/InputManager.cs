using UnityEngine;
using System.Collections;

public class InputManager
{
	//Input manager for keyboard and controller input
	public delegate void InputActionEvent();
	public delegate void InputMovementEvent(int direction);

	private static InputManager instance = null;

	private KeyCode selectKey;
	private KeyCode selectKey2;
	private KeyCode upKey;
	private KeyCode upKey2;
	private KeyCode downKey;
	private KeyCode downKey2;

	public event InputMovementEvent UpKey_Pressed;
	public event InputMovementEvent DownKey_Pressed;
	public event InputActionEvent SelectKey_Pressed;


	public static InputManager Instance
	{
		get
		{
			if(instance == null)
				instance = new InputManager();
			return instance;
		}
	}

	// Use this for initialization
	private InputManager () 
	{
		selectKey = KeyCode.Space;
		selectKey2 = KeyCode.Return;
     	upKey = KeyCode.W;
     	upKey2 = KeyCode.UpArrow;
     	downKey = KeyCode.S;
     	downKey2 = KeyCode.DownArrow;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		CheckInput();
	}

	private void CheckInput()
	{
		if(Input.GetKeyDown(upKey) || Input.GetKeyDown(upKey2))
		{
			if(UpKey_Pressed != null)
			{
				UpKey_Pressed(-1);
			}
		}
		if(Input.GetKeyDown(downKey) || Input.GetKeyDown(downKey2))
		{
			if(DownKey_Pressed != null)
				DownKey_Pressed(1);
		}
		if(Input.GetKeyDown(selectKey) || Input.GetKeyDown(selectKey2))
		{
			if(SelectKey_Pressed != null)
				SelectKey_Pressed();
		}
	}
}
