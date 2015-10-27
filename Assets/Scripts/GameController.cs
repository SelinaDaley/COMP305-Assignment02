/* Author: Selina Daley */
/* File: GameController.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script controls the text, enemy spawns, life spawns, score, and restart */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	/*public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
    public GameObject lifeOrb;*/
	public AudioSource gameMusic;
	public AudioSource gameOverMusic;
	public AudioSource coinSound;

	public GameObject player;
	public Text lifeText;
	public Text coinsText;
	//public Text scoreText;
	public Text timeText;
	public Text restartText;
	public Text gameOverText;

	public int life;
	public bool gameOver;

	//PRIVATE INSTANCE VARIABLES
	private bool _restart;
	private int _score;
	private int _coins;
	private int _time;

	void Start() {
		timeText.text = "Time: " + _time;
		restartText.text = "";
		gameOverText.text = "";
		gameOver = false;
		_restart = false;
		_score = 0;
		_time = 0;
		_coins = 0;

		UpdateScore ();
		UpdateLife ();
		UpdateCoins ();
	}

	void Update() {

		_time = Mathf.RoundToInt (Time.timeSinceLevelLoad);

		if (gameOver == false) 
		{
			timeText.text = "Time: " + _time;
		}

		if (_restart) {
			if(Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		if(gameOver) 
		{
			restartText.text = "Press 'R' to restart the game";
			_restart = true;
		} 
	}

	public void AddScore(int newScoreValue) {
		_score += newScoreValue;
		UpdateScore ();
	}

	public void UpdateScore() 
	{
		//scoreText.text = "Score: " + _score;
	}
	public void UpdateCoins() 
	{
		coinsText.text = "Coins: " + _coins;
	}
	public void DecreaseLife(int decLife)
	{
		life -= decLife;
		UpdateLife ();
	}
    public void IncreaseLife(int IncLife)
    {
        life += IncLife;
        UpdateLife();
    }
	public void IncreaseCoins(int coin)
	{
		_coins += coin;
		UpdateCoins ();
	}
	public void UpdateLife()
	{
		lifeText.text = "Life: " + life + "%";

		if(life == 0)
		{
			Destroy(player);
			GameOver();
		}
	}
	public void GameOver() 
    {
		gameMusic.Stop();
		gameOverMusic.Play();
		gameOverText.text = "Game Over!";
		gameOver = true;

	}
	public void PlayCoinSound()
	{
		coinSound.Play();
	}
}