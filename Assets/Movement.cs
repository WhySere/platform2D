using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int speed = 15;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public float jumpForce;

    public bool isGrounded;
    public GameObject groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isFacing = true;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, whatIsGround);

        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (moveHorizontal > 0 && isFacing) { Flip(); }
        if (moveHorizontal < 0 && !isFacing) { Flip(); }
    }

    void Flip()
    {

        if (isFacing)
        {
            sp.flipX = true;
        }

        else
        {
            sp.flipX = false;
        }

        isFacing = !sp.flipX;
    }
}