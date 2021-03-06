﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
        //get a handle on the particle system
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying) 
			return;
		
		Destroy (gameObject);
	}

    void onBecameInvisible()
    {
        Destroy(gameObject);
    }
}
