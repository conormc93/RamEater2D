using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public float speed;
    Rigidbody2D weaponVelocity;

    public PlayerController player;

    public GameObject deathEffect;
    public GameObject impactEffect;

    public int points;
    public int damageAmount;

    public float rotationSpeed;

	// Use this for initialization
	void Start () {

        weaponVelocity = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {

            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }

    }
	
	// Update is called once per frame
	void Update () {

        weaponVelocity.velocity = new Vector2(speed, weaponVelocity.velocity.y);

        weaponVelocity.angularVelocity = rotationSpeed; 
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
            //ScoreManager.AddPoints(points);

            other.GetComponent<EnemyHealthManager>().takeDamage(damageAmount);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
