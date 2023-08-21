using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {
	public float speed;
	private float x;
	public float destination;
	public float original;
	
	// Update is called once per frame
	void Update () 
	{
		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x < destination)
		{
			//Debug.Log ("Moving");
			x = original;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
	}
}
