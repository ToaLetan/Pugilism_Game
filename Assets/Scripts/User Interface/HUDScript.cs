using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour 
{
	GUIText timerText = null;

	GameObject healthBar = null;


	// Use this for initialization
	void Start () 
	{
		timerText = this.transform.FindChild("TimerText").guiText;

		healthBar = this.transform.FindChild("HealthBar").gameObject;
		//NOTE TO SELF: USE healthBar.transform.localScale to change the size.

		MatchTimeManager.Instance.StartTimer(10);
		MatchTimeManager.Instance.SecondElapsed += UpdateTimerText;
		MatchTimeManager.Instance.TimerComplete += UpdateTimerText;

		UpdateTimerText();
		PopHealthSegment(1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		MatchTimeManager.Instance.Update();
		//UpdateTimerText();
	}

	private void UpdateTimerText()
	{
		if(timerText != null)
			timerText.text = "Time: " + Mathf.CeilToInt(MatchTimeManager.Instance.MatchTime);

		PopHealthSegment(1); // Just testing here
	}

	private void PopHealthSegment(int damageNum) //Instantiates a segment of the health bar based on damage taken and visually "pops" it off of the HUD.
													//Will subscribe to an event for TakeDamage, might be based on player health scripts.
	{
		//Construct a new gameobject for a temporary health segment
		GameObject tempHealthSeg = new GameObject();
		tempHealthSeg.AddComponent<SpriteRenderer>();

		//Assign the new segment a sprite (existing health bar, coloured red for now)
		//TODO: Tween a colour for the sprite, maybe a white flash?
		SpriteRenderer tempSegRenderer = tempHealthSeg.GetComponent<SpriteRenderer>();
		tempSegRenderer.sprite = healthBar.GetComponent<SpriteRenderer>().sprite;
		tempSegRenderer.material.color = Color.red;

		//Set the initial position of the segment
		tempHealthSeg.transform.position = new Vector3(healthBar.transform.position.x + healthBar.renderer.bounds.size.x, healthBar.transform.position.y, healthBar.transform.position.z);

		//Randomize a velocity vector and push it in that direction, temp segment's script will handle the rest.
		float randDirectionX = 0;
		float randDirectionY = 0;

		//TODO: Probably set up a neater way of doing this.
		if(Random.value < 0.5f)
			randDirectionX = -1;
		else
			randDirectionX = 1;

		if(Random.value < 0.5f)
			randDirectionY = -1;
		else
			randDirectionY = 1;

		float randX = Random.value * randDirectionX * Time.deltaTime;
		float randY = Random.value * randDirectionY * Time.deltaTime;

		tempHealthSeg.AddComponent<DamageSegmentScript>();
		tempHealthSeg.GetComponent<DamageSegmentScript>().CurrentVelocity = new Vector2(randX, randY);
		tempHealthSeg.GetComponent<DamageSegmentScript>().CurrentDirection = new Vector2(randDirectionX, randDirectionY);
	}
}
