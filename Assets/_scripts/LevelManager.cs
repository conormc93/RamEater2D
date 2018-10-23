using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;

	private PlayerController player;

	//animation
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		Debug.Log("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);

		player.transform.position = currentCheckPoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}

}
