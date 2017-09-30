﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeController : MonoBehaviour {

	public Sprite pauseSprite;
	public Sprite resumeSprite;
	bool paused = false;

	public void PauseAndResume () {
		if (paused) {
			Time.timeScale = 1;
			this.GetComponent<Image> ().sprite = pauseSprite;
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Play ();
			paused = false;
		} else {
			Time.timeScale = 0;
			this.GetComponent<Image> ().sprite = resumeSprite;
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Pause ();
			paused = true;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
