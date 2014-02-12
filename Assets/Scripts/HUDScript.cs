using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		MatchTimeManager.Instance.StartTimer(10);
		MatchTimeManager.Instance.SecondElapsed += UpdateTimerText;
		MatchTimeManager.Instance.TimerComplete += UpdateTimerText;

		UpdateTimerText();
	}
	
	// Update is called once per frame
	void Update () 
	{
		MatchTimeManager.Instance.Update();
		//UpdateTimerText();
	}

	private void UpdateTimerText()
	{
		gameObject.guiText.text = "Time: " + Mathf.CeilToInt(MatchTimeManager.Instance.MatchTime);
	}
}
