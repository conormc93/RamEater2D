using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public Transform wallCheck;
    public Transform edgeCheck;
    public LayerMask whatIsWall;

    public float moveSpeed;
    public float wallCheckRadius;
    
    //booleans to check for whether the enemy
    //interacts with a wall or the edge of the level
    private bool hittingWall;
    private bool notAtEdge;
    public bool moveRight;

    // Use this for initialization
    void Start () {

        rigid2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        //asssign value of moveRight
        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            //flip the image of the enemy
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //move the enemy right
            rigid2D.velocity = new Vector2(moveSpeed, rigid2D.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            //move left
            rigid2D.velocity = new Vector2(-moveSpeed, rigid2D.velocity.y);
        }
		
	}
}
