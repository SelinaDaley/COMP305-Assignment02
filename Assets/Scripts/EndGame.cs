using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {

	public Text restartText;
	public Text gameOverText;
	private bool gameComplete = false;
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
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && gameComplete == true)
		{
			Invoke ("LoadIt", 0);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Boundary") 
		{
			if(other.tag == "Player") 
			{	
				Destroy(other.gameObject);
				gameController.GameOver();
				gameController.gameOverText.text = "Game Complete";
				gameController.restartText.text = "Press 'Space' to return to the main menu";
				gameComplete = true;
			}
		}
	}

	void LoadIt()
	{
		Application.LoadLevel (0);
	}
}
