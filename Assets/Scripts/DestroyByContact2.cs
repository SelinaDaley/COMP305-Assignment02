/* Author: Selina Daley */
/* File: DestroyByContact2.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script detects when the Bomb enemy collides with the player or players bomb/shot */

using UnityEngine;
using System.Collections;

public class DestroyByContact2 : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int coin;


	//PRIVATE INSTANCE VARIABLES
	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' Script");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Boundary") 
		{
			if(other.tag == "Player") 
			{
				gameController.PlayCoinSound();
				gameController.IncreaseCoins(coin);
				Destroy(gameObject);
			}
		}
	}
}