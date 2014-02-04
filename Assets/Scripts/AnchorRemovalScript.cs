using UnityEngine;
using System.Collections;

public class AnchorRemovalScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.name == "Anchor")
			Destroy(coll.gameObject);
	}
}
