/* Author: Selina Daley */
/* File: Down.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script moves the Gameobject it is attached to up or down on the screen */

using UnityEngine;
using System.Collections;

public class Down : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;
	public int coin;

	//PRIVATE INSTANCE VARIABLES
	private GameController gameController;
	
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed; //Moves up or down

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' Script");
		}

		gameController.IncreaseCoins(coin);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
