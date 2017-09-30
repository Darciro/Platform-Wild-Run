using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControll : MonoBehaviour {
	
	public bool isCollidingWithWall = false;
	public bool isCollidingWithGround = false;
	public bool isCollidingWithObstacle = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Wall") == true) {
			isCollidingWithWall = true;
		} 

		if (coll.CompareTag ("Ground") == true) {
			isCollidingWithGround = true;
		}

		if (coll.CompareTag ("Obstacle") == true) {
			isCollidingWithObstacle = true;
		}
	}

	// Update is called once per frame
	void OnTriggerExit2D (Collider2D coll) {
		if (coll.CompareTag ("Wall") == true) {
			isCollidingWithWall = false;
		} 

		if (coll.CompareTag ("Ground") == true) {
			isCollidingWithGround = false;
		}

		if (coll.CompareTag ("Obstacle") == true) {
			isCollidingWithObstacle = false;
		}
	}
}
