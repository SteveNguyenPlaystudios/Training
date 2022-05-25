using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public ParticleSystem dustRight;
    public ParticleSystem dustLeft;

    private Rigidbody2D rb;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;


    [HideInInspector]
    public static bool controllable;
    [HideInInspector]
    public static bool facingRight;

    public void Awake()
    {
        facingRight = true; 
        controllable = true;
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    public void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    public void FixedUpdate()
    {
        if (controllable)
        {
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            {
                rb.AddForce(new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, 0f), ForceMode2D.Impulse);
                if (moveHorizontal > 0.1f)
                {
                    facingRight = true;
                    dustRight.Play();
                } 
                if (moveHorizontal < -0.1f)
                {
                    facingRight = false;
                    dustLeft.Play();
                }
            }

            if (!isJumping && moveVertical > 0.1f)
            {
                rb.AddForce(new Vector2(0f, moveVertical * jumpForce * Time.deltaTime), ForceMode2D.Impulse);
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;   
        }
    }   
}
