using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour 
{
	public GameObject player;
	public GameObject gameManager;

	private Vector3 diceVelocity;
	private int diceValue = 0;
	private bool isDiceValuePassedToPlayer;

    void Start()
    {
		isDiceValuePassedToPlayer = false;
		player = GameObject.FindGameObjectWithTag("Player");
		gameManager = GameObject.FindGameObjectWithTag("GamaManager");
    }

    void FixedUpdate () 
	{
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (!isDiceValuePassedToPlayer && (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f))
		{
			switch (col.gameObject.name) 
			{
				case "-80":
					diceValue = -80;
					break;
				case "-40":
					diceValue = -40;
					break;
				case "-20":
					diceValue = -20;
					break;
				case "+20":
					diceValue = 20;
					break;
				case "+40":
					diceValue = 40;
					break;
				case "+80":
					diceValue = 80;
					break;
			}

			player.GetComponent<Player>().luckValue += diceValue;
			player.GetComponent<Player>().coinValue += diceValue * 10;
			isDiceValuePassedToPlayer = true;

			Invoke("DiceRolled", 0.5f);
		}
	}

	public void DiceRolled()
    {
		gameManager.GetComponent<GameManager>().DestroyDiceScene();
    }
}
