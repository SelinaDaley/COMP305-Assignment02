using UnityEngine;
using System.Collections;

public class greenSwitchController : MonoBehaviour {

	public GameObject shortHill;
	private GameObject hill;
	private Animator _animator; 
	//private Vector2 originPosition;

	// Use this for initialization
	void Start () {
		this._animator = gameObject.GetComponent<Animator> ();
		this.transform.position += new Vector3 (0f, 1f, 0f);
		//originPosition = this.transform.position;

		hill = GameObject.FindWithTag ("ShortHill");
	}
	
	// Update is called once per frame
	void Update () {

		hill = GameObject.FindWithTag ("ShortHill");

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			this._animator.SetBool("switchOn", false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			this._animator.SetBool("switchOn", true);
		}	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			//this._animator.SetBool("switchOn", true);
			hill.transform.position += new Vector3 (0f, 2.03f, 0f);
			hill.transform.parent = GameObject.Find("SpawnManager").transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			//this._animator.SetBool("switchOn", false);
			hill.transform.position += new Vector3 (0f, -2.03f, 0f);
			hill.transform.parent = GameObject.Find("SpawnManager").transform;
		}
	}
}
