using UnityEngine;
using System.Collections;

public class HillCrateCheck : MonoBehaviour {
	
	public GameObject crateTile;
	private GameObject crate;

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {

		crate = GameObject.FindWithTag ("Crate");

		if (crate == null) {
			SpawnCrate();
		}	
	}

	void SpawnCrate()
	{
		GameObject clone;
		Vector2 randomPosition = this.transform.position + new Vector3(-8f, 6f, 0f);
		clone = Instantiate(crateTile, randomPosition, Quaternion.identity) as GameObject;
		clone.transform.parent = GameObject.Find("hillLong(Clone)").transform;
	}
}
