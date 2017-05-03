using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 400f;
    public float maxJumpHeight = 10f;
    [Range (0, 1)]public float crouchSpeed = 10f;
    public bool airControl = true;
    public LayerMask whatIsGround;

    private bool facingRight = true;
    private Transform groundCheck;
    private float groundRadius = 0.2f;
    private bool grounded = false;
    private Transform ceilingCheck;
    private float ceilingRadius = 0.1f;
    private Animator anim;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator> ();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigid.velocity.y);
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch && Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
        {
            crouch = true;
        }

        anim.SetBool("Crouch", crouch);

        if (grounded || airControl)
        {
            // Ternary Operator 
            //     (condition ?(if) result :(else) alternate result)
            move = (crouch ? move * crouchSpeed : move); //SP equivalent is [if crouch]move * crouchSpeed[else]move[end if]

            anim.SetFloat("Speed", Mathf.Abs(move));

            rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }

        if (grounded && jump) //like [if (grounded) and (jump)]
        {
            anim.SetBool("Ground", false);
            grounded = false;
            rigid.AddForce(new Vector2(0f, jumpForce));
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;

        //invert X
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
