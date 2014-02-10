using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour 
{
	//Menu objects
	public GameObject menuCursor = null;
	public GameObject currentSelection = null;

	public GameObject startButton = null;
	public GameObject controlsButton = null;
	public GameObject quitButton = null;

	private List<GameObject> menuOptions = new List<GameObject>();

	private Vector3 returnPosition;
	
	// Use this for initialization
	void Start () 
	{
		menuCursor = gameObject.transform.FindChild("Menu_Select").gameObject;

		startButton = gameObject.transform.FindChild("Menu_Start").gameObject;
		controlsButton = gameObject.transform.FindChild("Menu_Controls").gameObject;
		quitButton = gameObject.transform.FindChild("Menu_Quit").gameObject;

		menuOptions.Add(startButton);
		menuOptions.Add(controlsButton);
		menuOptions.Add(quitButton);

		currentSelection = menuOptions[0];

		menuCursor.transform.position = new Vector3(menuCursor.transform.position.x, currentSelection.transform.position.y - menuCursor.renderer.bounds.size.y/4, 
		                                            menuCursor.transform.position.z);
		returnPosition = menuCursor.transform.position;

		InputManager.Instance.UpKey_Pressed += MoveCursor;
		InputManager.Instance.DownKey_Pressed += MoveCursor;
		InputManager.Instance.SelectKey_Pressed += Select;
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputManager.Instance.Update();

		if(menuCursor.transform.position.x != returnPosition.x)
			ReturnPosition();
	}

	private void MoveCursor(int direction)
	{
		int selectIndex = menuOptions.IndexOf(currentSelection) + direction;

		if(selectIndex >= menuOptions.Count)
			selectIndex = 0;
		if(selectIndex < 0)
			selectIndex = menuOptions.Count - 1;

		currentSelection = menuOptions[selectIndex];

		menuCursor.transform.position = new Vector3(menuCursor.transform.position.x, currentSelection.transform.position.y - menuCursor.renderer.bounds.size.y/4, 
		                                            menuCursor.transform.position.z);
		returnPosition = menuCursor.transform.position;
	}

	private void Select()
	{
		//Vector3 returnPosition = menuCursor.transform.position;

		menuCursor.transform.position = Vector3.Lerp(menuCursor.transform.position, currentSelection.transform.position, 0.2f);
	}

	private void ReturnPosition()
	{
		menuCursor.transform.position = Vector3.Lerp(menuCursor.transform.position, returnPosition, 0.2f);
	}

}
