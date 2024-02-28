using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10f;
    public float XSpeed => xSpeed;
    [SerializeField] private float jumpForce = 800f;

    private Rigidbody2D rb;
    private float xMoveInput;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    public bool moving = false;
    public bool IsGrounded => isGrounded;

    private bool shouldJump = false;

    private void Awake()
    {
        rb  = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }
        
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            moving = true;

        }
        else
        {
            moving = false;
        }
       
    }

    private void FixedUpdate()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        isGrounded = col != null;


        rb.velocity = new Vector2(xMoveInput + rb.velocity.x, rb.velocity.y);
        if (rb.velocity.x > 10f)
        {
            rb.velocity = new Vector2(10f, rb.velocity.y);
        }
        else if (rb.velocity.x < -10f)
        {
            rb.velocity = new Vector2(-10f, rb.velocity.y);
        }
        if (shouldJump == true)
        {
            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }                           
            shouldJump = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}

