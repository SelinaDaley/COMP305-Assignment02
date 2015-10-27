/* Author: Selina Daley */
/* File: DestroyByTime.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script controls the life span of the GameObject that it is attached to */

using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float lifetime;

	void Start () {
		Destroy (gameObject, lifetime);
	}

}
