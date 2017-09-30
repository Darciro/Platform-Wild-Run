using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharColliderController : MonoBehaviour {

	public bool isColliding = false;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Wall") == true) {
			isColliding = true;
		}
	}
	
	// Update is called once per frame
	void OnTriggerExit2D (Collider2D coll) {
		if (coll.CompareTag ("Wall") == true) {
			isColliding = false;
		}
	}
}
