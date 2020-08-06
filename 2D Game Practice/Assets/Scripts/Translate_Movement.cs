using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate_Movement : MonoBehaviour
{

    [SerializeField] float speed, jumpForce, jumpTime;
    private float jumpTimeBase;
    Rigidbody2D rb;
    Vector3 movement;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeBase = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {

        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        flip();

    }

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
}
