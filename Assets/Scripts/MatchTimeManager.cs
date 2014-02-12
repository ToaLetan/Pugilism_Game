using UnityEngine;
using System.Collections;

public class MatchTimeManager
{
	public delegate void TimerEvent();

	public event TimerEvent TimerStart;
	public event TimerEvent TimerComplete;
	public event TimerEvent SecondElapsed;

	private static MatchTimeManager instance = null;

	private float matchTime = 0;
	private float matchLength = 0;
	private float second = 0;

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
			second += Time.deltaTime;

			if(matchTime <= 0)
			{
				isTimerRunning = false;
				matchTime = 0;

				//Fire timer complete event
				if(TimerComplete != null)
					TimerComplete();
			}

			//Fire the SecondElapsed event, used to limit HUD time update to once per second.
			if(second >= 1)
			{
				second = 0;
				if(SecondElapsed != null)
					SecondElapsed();
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
