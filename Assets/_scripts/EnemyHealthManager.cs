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
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(points);
            Destroy(gameObject);
        }
	}

    public void takeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        GetComponent<AudioSource>().Play();
    }
}
