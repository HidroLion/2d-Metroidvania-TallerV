using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Animator animator;


    // ---- MOVEMENT Variables ----

    private float moveInput;
    Vector3 movement;
    [SerializeField] float speed;


    // ---- JUMP Variables ----

    [SerializeField] float jumpForce;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRaious;
    public LayerMask whatGround;

    public float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    private int extraJump;
    public int extraJumpsValue;
    public float secondJumpForce;

    // ---- DASH Variables ----

    [SerializeField] float dashForce, initialdashTime;
    private float dashTime;
    private bool canDash;

    //private bool facingRight = true; ----> Los usa la Funcion "Flip Sprite"; Pero no se esta usando en este momento.



    // ----------------------------------------------------------- CODE ---------------------------------------------------------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJump = extraJumpsValue;
        canDash = true;
        dashTime = initialdashTime;


    }

    // Update is called once per frame
    void Update()
    {
        // ---- JUMP Controller ----

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRaious, whatGround);

        if (isGrounded == true && Input.GetButtonDown("Jump") && extraJump > 0)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        }
        else if (Input.GetButtonDown("Jump") && extraJump > 0) // Aqui se hace el doble salto.
        {
            rb.velocity = Vector2.up * secondJumpForce;
            animator.SetBool("jumping", true);
            extraJump--;
        }


        if (Input.GetButton("Jump") && isJumping == true)
        {
            
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (isGrounded == true)
        {
            animator.SetBool("jumping", false);
            extraJump = extraJumpsValue;
        }
        else
        {
            animator.SetBool("jumping", true);
        }

        // ---- End JUMP Controller ----

        // ---- DASH Controller----


        if (movement.x > 0 && Input.GetKeyDown(KeyCode.X))
        {

            if (canDash)
            {
                rb.velocity = Vector2.right * dashForce;
                canDash = false;
                Invoke("cooldownDash", 2);
            }

        }

        if (movement.x < 0 && Input.GetKeyDown(KeyCode.X))
        {

            if (canDash)
            {
                rb.velocity = Vector2.left * dashForce;
                canDash = false;
                Invoke("cooldownDash", 2);
            }
        }




        // ---- End DASH Controller ----

    }

    void FixedUpdate()
    {


        // -------------------------- Movement by Physics--------------------
        //moveInput = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //animator.SetFloat("speed", Math.Abs(moveInput));

        //if (facingRight == false && moveInput > 0)
        //{
        //    flipSprite();
        //}
        //else if (facingRight == true && moveInput < 0)
        //{
        //    flipSprite();
        //}

        // -------------------------- Movement by Transform
        moveInput = Input.GetAxis("Horizontal");
        movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        animator.SetFloat("speed", Math.Abs(moveInput));

        flip();

    }

    //void flipSprite() // Alternative function for Flip
    //{
    //    facingRight = !facingRight;

    //    Vector3 scaler = transform.localScale;
    //    scaler.x *= -1;
    //    transform.localScale = scaler;
    //}

    void flip()
    {

        if (movement.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (movement.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

    }

    void cooldownDash()
    {
        canDash = true;
        dashTime = initialdashTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Collectable")
        {
            Destroy(collider.gameObject);
        }
    }

}
