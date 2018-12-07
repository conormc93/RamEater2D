using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    //instance variables
    Rigidbody2D weaponVelocity;
    public PlayerController player;

    public GameObject deathEffect;
    public GameObject impactEffect;

    public int points;
    public int damageAmount;

    public float speed;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        //find these objects in the game
        weaponVelocity = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        //change direction of speed and rotation of weapon
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
        //if the weapon interacts with an object with this tag
        if(other.tag == "Enemy")
        {
            //apply damage to that object
            other.GetComponent<EnemyHealthManager>().takeDamage(damageAmount);
        }

        //create effects when the objects are interacted with
        Instantiate(impactEffect, transform.position, transform.rotation);

        //Destroy the weapon used
        Destroy(gameObject);
    }
}
