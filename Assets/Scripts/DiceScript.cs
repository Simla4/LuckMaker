using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour 
{

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	private bool isTossed = false;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () 
	{
		RollDice();
	}

	private void RollDice()
    {
		diceVelocity = rb.velocity;

		if (!isTossed)
		{
			isTossed = true;

			float dirX = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, 0.0f, dirZ);
		}
	}
}
