using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar = KeyCode.Space;
    public KeyCode L = KeyCode.LeftArrow;
    public KeyCode R = KeyCode.RightArrow;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    public Transform Target;
    public float Camerspeed;
    public float minX,MaxX;
    public float minY,maxY;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)  //When user presses the space button ONCE
        {
            Jump(); //see function definition below
        }

        if (Input.GetKey(L)) //When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //player character moves horizontally to the left along the x-axis without disrupting jump

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R)) //When user presses the right arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //player character moves horizontally to the right along the x-axis without disrupting jump

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
       anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
       
Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);

if(Target != null)
{
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //player character jumps vertically along the y-axis without disrupting horizontal walk
        anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
    }

void FixedUpdate(){
grounded= Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


    }
    }
}