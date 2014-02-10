using UnityEngine;
using System.Collections;

public class MatchTimeManager
{
	public delegate void TimerEvent();

	public event TimerEvent TimerStart;
	public event TimerEvent TimerComplete;

	private static MatchTimeManager instance = null;

	private float matchTime = 0;
	private float matchLength = 0;

	private bool isTimerRunning = false;

	public static MatchTimeManager Instance
	{
		get
		{
			if(instance == null)
				instance = new MatchTimeManager();
			return instance;
		}
	}

	public float MatchTime
	{
		get { return matchTime; }
		set { matchTime = value; }
	}

	public bool IsTimerRunning
	{
		get { return isTimerRunning; }
	}

	// Use this for initialization
	private MatchTimeManager () 
	{
	
	}
	
	// Update is called once per frame
	public void Update () 
	{
		UpdateTimer();
	}

	private void UpdateTimer()
	{
		if (isTimerRunning)
		{
			matchTime -= Time.deltaTime;

			if(matchTime <= 0)
			{
				isTimerRunning = false;

				//Fire timer complete event
				if(TimerComplete != null)
					TimerComplete();
			}
		}
	}

	public void StartTimer(float lengthOfMatch)
	{
		if(!isTimerRunning)
		{
			matchTime = lengthOfMatch;
			isTimerRunning = true;

			if(TimerStart != null)
				TimerStart();
		}
	}
}
