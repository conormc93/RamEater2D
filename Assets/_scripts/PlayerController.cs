using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    private Animator anim;
    public Transform throwPoint;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject weapon;

    public float moveSpeed;
	public float jumpHeight = 15;
	public float maxSpeed = 2f;
	public float groundCheckRadius;

	private bool doubleJump;
	private bool grounded;

	// Use this for initialization
	void Start () {
		
		rigid2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate(){
        //set to true 
        //player is always on teh ground
        //unless jumping
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
    
    // Update is called once per frame
	void Update () {

        // determine the movement of the player
		float move = Input.GetAxis("Horizontal");
		rigid2D.velocity = new  Vector2(move * maxSpeed, rigid2D.velocity.y);

        //if the player is on teh ground
        //teh player is capable of double jumping
		if (grounded)
			doubleJump = false;
		
		anim.SetBool("Grounded", grounded);

		// Jump Code
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			Jump();
		}

		// Double Jump Code
        // If the player is not grounded and hasnt double jumped, jump again
		if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
		{
			Jump();
			doubleJump = true;
		}

        // Weapon code
        if(Input.GetKeyDown(KeyCode.X))
        {
            //create the weapon at this point 
            Instantiate(weapon, throwPoint.position, throwPoint.rotation);
        }

		//set animation
		anim.SetFloat ("Speed", Mathf.Abs(rigid2D.velocity.x));

        //flips the player character
        //makes it look like he is going left or right
        if (rigid2D.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 0f);
        else if(rigid2D.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 0f);
         

    }

	public void Jump(){
		rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
	}


	

}
