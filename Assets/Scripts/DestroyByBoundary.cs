/* Author: Selina Daley */
/* File: DestroyByBoundary.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script detects when a Gameobject exits the screen and destroys it */

using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		Destroy (other.gameObject);
	}

	void OnCollisionExit2D(Collision2D other)
	{
		Destroy (other.gameObject);
	}

}
