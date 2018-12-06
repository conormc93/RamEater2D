using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public float speed;
    Rigidbody2D weaponVelocity;

    public PlayerController player;

	// Use this for initialization
	void Start () {

        weaponVelocity = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;

        }

    }
	
	// Update is called once per frame
	void Update () {

        weaponVelocity.velocity = new Vector2(speed, weaponVelocity.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
