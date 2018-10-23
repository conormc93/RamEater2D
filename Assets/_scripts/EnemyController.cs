using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    Rigidbody2D rigid2D;

    public float moveSpeed;
    public bool moveRight;
	// Use this for initialization
	void Start () {

        rigid2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if (moveRight)
        {

            rigid2D.velocity = new Vector2(moveSpeed, rigid2D.velocity.y);
        }
        else
        {
            rigid2D.velocity = new Vector2(-moveSpeed, rigid2D.velocity.y);
        }
		
	}
}
