using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public int shootForce;
    Vector2 shootAngle;
    Vector2 direction;
    Vector2 mousePos;
    Rigidbody2D rbSelf;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        rbSelf = gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            direction = new Vector3(mousePos.x - rbSelf.transform.position.x, mousePos.y - rbSelf.transform.position.x);
            direction.Normalize();
            rb.AddForce(-direction * shootForce);
        }
    }
}
