using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;
	public GameObject explosion;
	public int changeLife;
	
	//PRIVATE INSTANCE VARIABLES
	private GameController gameController;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed; //Moves up or down

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' Script");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.transform.position.y <= -0.15f)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Boundary") 
		{
			if(other.tag == "Player") 
			{
				Instantiate (explosion, transform.position, transform.rotation);
				gameController.DecreaseLife (changeLife);
				Destroy(this.gameObject);
			} 
		}
	}
}
