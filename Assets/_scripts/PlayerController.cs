using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigid2D;
	public float moveSpeed;
	public float jumpHeight=15;
	public float maxSpeed = 2f;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private bool doubleJump;
	private bool grounded;

	private Animator anim;

	// Use this for initialization
	void Start () {
		
		rigid2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Horizontal");
		rigid2D.velocity = new  Vector2(move * maxSpeed, rigid2D.velocity.y);

		if (grounded)
			doubleJump = false;
		
		anim.SetBool("Grounded",grounded);
		// Your jump code:
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			//rigid2D.velocity = new Vector2(rigid2D.velocity.x, jum pHeight);
			Jump();
		}
		// Your jump code:
		if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
		{
			//rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
			Jump();
			doubleJump = true;
		}
		//set animation
		anim.SetFloat ("Speed", Mathf.Abs(rigid2D.velocity.x));
	}

	public void Jump(){
		rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
	}

	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
	}

}
