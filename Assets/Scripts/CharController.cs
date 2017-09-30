using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour {

	/* CharColliderController bottomCollider;
	CharColliderController rightCollider;
	CharColliderController leftCollider; */

	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;

	ColliderControll bottomCollider;
	ColliderControll rightCollider;

	bool jumping = false;
	bool down = false;
	bool grounded = false;
	bool facingForward = true;

	public float speed = 0;

	int score = 0;

	void Start () {
		/*
		bottomCollider = GetComponentsInChildren<CharColliderController>()[0];
		rightCollider = GetComponentsInChildren<CharColliderController>()[1];
		leftCollider = GetComponentsInChildren<CharColliderController>()[2];
		*/

		bottomCollider = GetComponentsInChildren<ColliderControll> () [0];
		rightCollider = GetComponentsInChildren<ColliderControll> () [1];
	}

	// Update is called once per frame
	void Update () {
		// Android input touch
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];

			switch (touch.phase) {
			case TouchPhase.Began:
				startPos = touch.position;
				break;

			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				if (swipeDistVertical > minSwipeDistY) {
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					// Up swipe
					if (swipeValue > 0) { 
						JumpForward(true);
					}
					// Down swipe
					else if (swipeValue < 0) {
						// Shrink ();
					}
				}

				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				if (swipeDistHorizontal > minSwipeDistX) {
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					// Right swipe
					if (swipeValue > 0) { 
						// MoveRight ();
					}
					// Left swipe
					else if (swipeValue < 0) {
						// MoveLeft ();
					}
				}
				break;
			}
		}

		// PC Inputs
		if (Input.GetKeyDown (KeyCode.Space)) {
			JumpForward(true);
		}

		// Check for wall and ground collisions
		if (bottomCollider.isCollidingWithGround) {
			grounded = true;
			jumping = false;
			this.GetComponent<Animator> ().speed = 1;
		} else {
			grounded = false;
			jumping = true;
			this.GetComponent<Animator> ().speed = 0;
		}
			
		if (rightCollider.isCollidingWithObstacle || rightCollider.isCollidingWithGround) {
			grounded = true;
			jumping = false;
			this.GetComponent<Animator> ().speed = 0;
		}

		// Check if char falls
		if (this.transform.position.y <= -5) {
			SceneManager.LoadScene("GameOver");
		}
			
	}

	void FixedUpdate () {
	
		// Set the velocity of the character
		this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);

		if (rightCollider.isCollidingWithWall) {
			JumpForward (false);
		}
			
	}

	void JumpForward(bool forward){
		if (forward) {
			if (!jumping && grounded) {
				// this.GetComponent<Animator> ().speed = 0;
				this.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 1000f));	
			}
		} else {
			// if (facingForward == false) {
				speed = speed * -1;
				this.transform.localScale = new Vector2 (-this.transform.localScale.x, this.transform.localScale.y);
				// this.GetComponent<Animator> ().speed = 0;
				this.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-0, 1000f));
				StartCoroutine ("FlipChar");
				facingForward = true;
			// }
		}
	}

	IEnumerator FlipChar(){
		yield return new WaitForSeconds (0.6f);
		speed = speed * -1;
		this.transform.localScale = new Vector2 (-this.transform.localScale.x, this.transform.localScale.y);
		facingForward = false;
		// this.GetComponent<Animator> ().speed = 1;
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Coin") {
			Destroy (other.gameObject);
			this.GetComponent<AudioSource> ().Play ();

			this.score++;
			this.UpdateScore ();
		}
	}

	public void UpdateScore(){
		GameObject.Find ("Score").GetComponent<UnityEngine.UI.Text> ().text = "PONTOS: " + this.score;
	}
		

}
