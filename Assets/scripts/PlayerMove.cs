using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   

    public float runSpeed=2;

    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public  bool betterJump = false;

    public float fallMultiplayer = 0.5f;

    public float lowJumpMultiplayer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    private float[] positionTrick = { 
        (float)1.027, //0
        (float)0.024, //1
        (float)2.258, //2
        (float)-0.549,//3
        (float)2.812, //4
        (float)1.236  //5
    };

    private bool trickOnCooldwon = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    IEnumerator checkTrick()
    {
        trickOnCooldwon = true;

        gameObject.transform.position = (new Vector2(positionTrick[4], positionTrick[5]));

        yield return new WaitForSeconds(2f);

        trickOnCooldwon = false;
    }

    void FixedUpdate()
    {
        if (!trickOnCooldwon && Input.GetKey("k"))
        {
            StartCoroutine(checkTrick());
            
        }
            if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left")) 
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if (CheckGround.isGrounded == false) {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false); 
        }

        if (betterJump){
            if (rb2D.velocity.y<0) {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;   
            }

            if (rb2D.velocity.y >0 && ! Input.GetKey("space")) {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }


    }
}
