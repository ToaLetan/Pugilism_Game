using UnityEngine;
using System.Collections;


public struct GamePadAxis
{
	private string _LS_X;
	private string _LS_Y;
	private string _RS_X;
	private string _RS_Y;

	private string _DPAD_X;
	private string _DPAD_Y;

	private string _RT;
	private string _LT;

	public string LS_X
	{
		get
		{
			return _LS_X;
		}
	}

	public string LS_Y
	{
		get
		{
			return _LS_Y;
		}
	}

	public string RS_X
	{
		get
		{
			return _RS_X;
		}
	}

	public string RS_Y
	{
		get
		{
			return _RS_Y;
		}
	}
	
	public string DPAD_X
	{
		get
		{
			return _DPAD_X;
		}
	}

	public string DPAD_Y
	{
		get
		{
			return _DPAD_Y;
		}
	}
	
	public string RT
	{
		get
		{
			return _RT;
		}
	}

	public string LT
	{
		get
		{
			return _LT;
		}
	}

	public GamePadAxis(int playerIndex)
	{

		_LS_X = "L_XAxis_" + (playerIndex + 1).ToString();
		_LS_Y = "L_YAxis_" + (playerIndex + 1).ToString();
		_RS_X = "R_XAxis_" + (playerIndex + 1).ToString();
		_RS_Y = "R_YAxis_" + (playerIndex + 1).ToString();

		_DPAD_X = "DPad_XAxis_" + (playerIndex + 1).ToString();
		_DPAD_Y = "DPad_YAxis_" + (playerIndex + 1).ToString();

		_RT = "TriggersL_" + (playerIndex + 1).ToString();
		_LT = "TriggersR_" + (playerIndex + 1).ToString();
	
	}
}


public struct GamePadButtons
{
	private string _A;
	private string _B;
	private string _X;
	private string _Y;
	
	private string _LB;
	private string _RB;
	
	private string _LS;
	private string _RS;
	
	private string _START;
	private string _BACK;

	public string A
	{
		get
		{
			return _A;
		}
	}

	public string B
	{
		get
		{
			return _B;
		}
	}
	public string X
	{
		get
		{
			return _X;
		}
	}
	public string Y
	{
		get
		{
			return _Y;
		}
	}
	
	public string LB
	{
		get
		{
			return _LB;
		}
	}
	public string RB
	{
		get
		{
			return _RB;
		}
	}
	
	public string LS
	{
		get
		{
			return _LS;
		}
	}
	public string RS
	{
		get
		{
			return _RS;
		}
	}
	
	public string START
	{
		get
		{
			return _START;
		}
	}
	public string BACK
	{
		get
		{
			return _BACK;
		}
	}

	public GamePadButtons(int playerIndex)
	{
		_A = "A_" + (playerIndex + 1).ToString();
		_B = "B_" + (playerIndex + 1).ToString();
		_X = "X_" + (playerIndex + 1).ToString();
		_Y = "Y_" + (playerIndex + 1).ToString();

		_LB = "LB_" + (playerIndex + 1).ToString();
		_RB = "RB_" + (playerIndex + 1).ToString();;

		_LS = "LS_" + (playerIndex + 1).ToString();
		_RS = "RS_" + (playerIndex + 1).ToString();

		_START = "Start_" + (playerIndex + 1).ToString();
		_BACK = "Back_" + (playerIndex + 1).ToString();
	}
}


public class GAMEPAD
{
	public static GamePadAxis[] AXIS = new GamePadAxis[4] { new GamePadAxis(0), new GamePadAxis(1), new GamePadAxis(2), new GamePadAxis(3) };
	public static GamePadButtons[] BUTTONS = new GamePadButtons[4] { new GamePadButtons(0), new GamePadButtons(1), new GamePadButtons(2), new GamePadButtons(3) };
}