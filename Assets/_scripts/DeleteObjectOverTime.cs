using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectOverTime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //decrement lifetime of object
        lifetime -= Time.deltaTime;

        if(lifetime < 0)
        {
            //destroy the object 
            Destroy(gameObject); 
        }
		
	}
}
