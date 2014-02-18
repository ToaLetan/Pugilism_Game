using UnityEngine;
using System.Collections;

public class DamageSegmentScript : MonoBehaviour 
{
	private const float DECELERATION = 0.05f;
	private const float MAXDECAYTIME = 3.0f;

	private Vector2 currentVelocity = Vector2.zero;
	private Vector2 currentDirection = Vector2.zero;

	private float currentDecayTime = 0.0f;

	public Vector2 CurrentVelocity
	{
		get { return currentVelocity; }
		set { currentVelocity = value; }
	}

	public Vector2 CurrentDirection
	{
		get { return currentDirection; }
		set { currentDirection = value; }
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdatePosition();
		UpdateDecayTimer();
	}

	private void UpdatePosition()
	{
		currentVelocity -= new Vector2(DECELERATION * currentDirection.x, DECELERATION * currentDirection.y) * Time.deltaTime;

		gameObject.transform.position += new Vector3(currentVelocity.x, currentVelocity.y, gameObject.transform.position.z);
	}

	private void UpdateDecayTimer()
	{
		if(currentDecayTime < MAXDECAYTIME)
			currentDecayTime += Time.deltaTime;
		else
			Destroy(gameObject);
	}
}
