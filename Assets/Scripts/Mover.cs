/* Author: Selina Daley */
/* File: Mover.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script moves the Gameobject it is attached to left or right on the screen */

using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;
	public Transform shotSpawn;
	public GameObject enemyShot1;
	public float fireRate;
	public GameObject explosion;
	public int changeLife;

	//PRIVATE INSTANCE VARIABLES
	private float _nextFire;
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
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed; //Moves the gameobject horizontally
	}

	void Update () {
		this._CheckFire ();
	}
	
	private void _CheckFire()
	{
		if(Time.time > _nextFire)
		{
			GameObject clone;
			_nextFire = Time.time + fireRate;
			clone = Instantiate (enemyShot1, shotSpawn.position, shotSpawn.rotation) as GameObject;
			clone.transform.parent = GameObject.Find("SpawnManager").transform;
		}		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Instantiate (explosion, transform.position, transform.rotation);
		gameController.DecreaseLife (changeLife);
		Destroy(this.gameObject);
	}
}
