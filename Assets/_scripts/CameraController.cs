using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController player;
    public bool isFollowing;

    public float xOffSet;
    public float yOffSet;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
        {
            //camera follows the player
            transform.position = new Vector3(player.transform.position.x + xOffSet, player.transform.position.y + yOffSet, transform.position.z);
        }
	}
}
