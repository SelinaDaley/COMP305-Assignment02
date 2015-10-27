using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	//public float speed = 1;
	//public float floatStrength = 1; //the range of y positions that are possible.
	
	//PRIVATE INSTANCE VARIABLES
	//private float _xPos;
	//private float _yPos;
	
	void Start()
	{
		//this._xPos = this.transform.position.x;
		//this._yPos = this.transform.position.y;
	}
	
	void Update()
	{
		//_xPos += speed; 
		//transform.position = new Vector3(((float)Mathf.Sin(Time.time)) * speed, _yPos + ((float)Mathf.Sin(Time.time) * floatStrength), transform.position.z);
		//transform.position = new Vector3(_xPos + (float)Mathf.Sin(Time.time) * speed, _yPos + ((float)Mathf.Sin(Time.time) * floatStrength), transform.position.z);
		//this.transform.parent = GameObject.Find("SpawnManager").transform;
	}


	/*public float amplitudeX = 10.0f;
	public float amplitudeY = 5.0f;
	public float omegaX = 1.0f;
	public float omegaY = 5.0f;
	public float index;

	public void Update(){
		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
		transform.localPosition= new Vector3(x,y,0);
	}*/
}
