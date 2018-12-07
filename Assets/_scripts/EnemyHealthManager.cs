using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;

    public GameObject deathEffect;

    public int points;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(enemyHealth <= 0)
        {
            //play the particle effect
            Instantiate(deathEffect, transform.position, transform.rotation);
            //add points to the score for the player
            ScoreManager.AddPoints(points);
            //destroy the particle effect
            Destroy(gameObject);
        }
	}

    public void takeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        GetComponent<AudioSource>().Play();
    }
}
