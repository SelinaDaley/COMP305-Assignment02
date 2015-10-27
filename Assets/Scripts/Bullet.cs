using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed; //Moves the gameobject horizontally
	}
	
	// Update is called once per frame
	void Update () {
	}
}
