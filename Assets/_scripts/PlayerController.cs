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

    public Transform throwPoint;
    public GameObject weapon;

	// Use this for initialization
	void Start () {
		
		rigid2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
    
    // Update is called once per frame
	void Update () {

		float move = Input.GetAxis("Horizontal");
		rigid2D.velocity = new  Vector2(move * maxSpeed, rigid2D.velocity.y);

		if (grounded)
			doubleJump = false;
		
		anim.SetBool("Grounded",grounded);

		// Jump Code
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			Jump();
		}

		// Double Jump Code
		if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
		{
			
			Jump();
			doubleJump = true;
		}

        // Weapon code
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(weapon, throwPoint.position, throwPoint.rotation);
        }

		//set animation
		anim.SetFloat ("Speed", Mathf.Abs(rigid2D.velocity.x));

        
        if (rigid2D.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 0f);
        else if(rigid2D.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 0f);
         

    }

	public void Jump(){
		rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
	}

	

}
