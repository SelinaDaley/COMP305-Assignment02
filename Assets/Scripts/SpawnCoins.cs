using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour {

	public Transform[] coinSpawns;
	public GameObject silverCoin;
	
	// Use this for initialization
	void Start () {
		
		Spawn();
	}
	
	void Spawn()
	{
		for (int i = 0; i < coinSpawns.Length; i++)
		{
			int coinFlip = Random.Range (0, 1);
			if (coinFlip == 0)
			{
                GameObject clone;
                clone = Instantiate(silverCoin, coinSpawns[i].position, Quaternion.identity) as GameObject;
                clone.transform.parent = GameObject.Find("SpawnManager").transform;
			}
		}
	}
}
