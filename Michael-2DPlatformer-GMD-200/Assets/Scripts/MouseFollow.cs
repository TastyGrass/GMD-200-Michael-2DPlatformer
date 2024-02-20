using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Vector2 input;
    public float turnRate;
    private Rigidbody2D rb;
    Vector2 mousePos;
    private bool flipped = false;
    public GameObject player;
    private bool facingRight;
    private bool flippedX = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        facingRight = player.GetComponent<PlayerAnimation>().FacingRight;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
       if (facingRight)
        {
            if (mousePos.x - transform.position.x < 0 && flippedX == true)
            {
                FlipX();
            }
            else if (mousePos.x - transform.position.x >= 0 && flippedX == false)
            {
                FlipX();
            }

        }
        else if (!facingRight)
        {
            if (mousePos.x - transform.position.x > 0 && flippedX == true)
            {
                FlipX();
            }
            else if (mousePos.x - transform.position.x <= 0 && flippedX == false)
            {
                FlipX();
            }
        }

       /* if (facingRight && flipped == false)
        {
            FlipY();
        }
        else if (!facingRight && flippedX == true)
        {
            FlipOnce();
        }*/
        
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

    }

    private void FlipY()
    {
        flipped = !flipped;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
    }

    private void FlipX()
    {
        flippedX = !flippedX;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


}
