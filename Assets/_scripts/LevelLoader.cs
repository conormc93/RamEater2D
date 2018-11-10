using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private bool playerInZone;

    public string loadLevel;

	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W) && playerInZone)
        {
            SceneManager.LoadScene(loadLevel);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true;
            Debug.Log("Inside onTriggerEnter2D");
        }
    }

    // if the player enters the level exit
    // gives the player the option whether
    // they want to exit level or go back
    // and play level more
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = false;
            Debug.Log("Inside onTriggerExit2D");
        }
    }
}
