using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Get components

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public GameObject groundCheck;
    public LayerMask whatIsGround;

    // Statistiche del Player
    public int vita;
    private int speed = 15;
    public float jumpForce;
    private int doubleJump;

    //Groundcheck
    public bool isGrounded;
    private float checkRadius = 1f;

    //SpriteFlipper
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
        //Movimento orizzontale

        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);


        //Doppio Salto

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            doubleJump = 0;
        }

        if (Input.GetButtonDown("Jump") && doubleJump <= 1)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                doubleJump++;
            }

            else
            {
                doubleJump = 1;

                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                doubleJump++;
            }  
        }

        // Trigger della gestione del Flip
        if (moveHorizontal > 0 && isFacing) { Flip(); }
        if (moveHorizontal < 0 && !isFacing) { Flip(); }
    }

    //Gestione del Flip della sprite 

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

    void OnTriggerEnter2D(Collider2D Nemico)
    {
        vita = vita - Nemico.GetComponent<Enemy>().danno;

        Debug.Log("aaaa");

        if (vita <= 0)
        {
            transform.position = new Vector2(0f, 0f);
            vita = 2;
        }
    }
}