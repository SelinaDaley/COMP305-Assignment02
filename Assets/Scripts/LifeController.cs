using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public int changeLife;
	
	//PRIVATE INSTANCE VARIABLES
	private GameController gameController;

	// Use this for initialization
	void Start () 
	{
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

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Boundary") 
		{
			if(other.tag == "Player") 
			{
				if(this.tag == "Spikes") 
				{
					gameController.DecreaseLife (changeLife);
					//Destroy(gameObject);
				}
				else if(this.tag == "Life") 
				{
					gameController.IncreaseLife (changeLife);
					Destroy(gameObject);
				}
			} 
		}
	}
}
