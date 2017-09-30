using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrroller : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		// Vector3 characterPosition = GameObject.Find ("Character").transform.position;
		// this.transform.position = new Vector3 (characterPosition.x + 1, characterPosition.y + 3, characterPosition.z - 10);

		if (target) {
			Vector3 point = cam.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.1f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
