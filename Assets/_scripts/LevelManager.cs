using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;

	private PlayerController player;  

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

    private new CameraController camera;
    private float gravityStore;
	
    // Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		
		StartCoroutine("RespawnPlayerCo");
	}

    public IEnumerator RespawnPlayerCo()
    {
        Debug.Log("DEBUG : Player Respawn");

        // Disable the player while respawning
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        camera.isFollowing = false;

        // Instantiate death particle where player died
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        // stop player when respawn
        // player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = new Vector3(currentCheckPoint.transform.position.x, currentCheckPoint.transform.position.y, player.transform.position.z);

        // Re enable player
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        camera.isFollowing = true;

        // Instantiate respawn particle where player respawns
        Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);

    }

}
