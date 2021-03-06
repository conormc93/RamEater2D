﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager; 

	// Use this for initialization
	void Start () {
		// find objects in scene attcahed to levelManager
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			levelManager.RespawnPlayer();
            Debug.Log(other.name);
		}

	}
}
