using UnityEngine;
using System.Collections;

public class BlockCoinCreation : MonoBehaviour {

	public GameObject bronzeCoin;
	private int coinCount;//top

	// Use this for initialization
	void Start () {
		coinCount = Random.Range(0, 7);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(coinCount > 0)
		{
			GameObject clone;
			Vector2 coinPosition = new Vector2( this.transform.position.x, this.transform.position.y + 1.0f);
			clone = Instantiate(bronzeCoin, coinPosition, Quaternion.identity) as GameObject;
			clone.transform.parent = GameObject.Find("SpawnManager").transform;
			coinCount--;
		}
	}
}
