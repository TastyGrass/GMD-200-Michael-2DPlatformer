using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public int shootForce;
    private Vector2 shootAngle;
    private Vector2 direction;
    private Vector2 mousePos;
    private Rigidbody2D rbSelf;
    public GameObject bullet;
    public Transform spawnLocation;
    public bool shoot = false;
  
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        rbSelf = gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0) && shoot == true)
        {
            Fire();
            direction = new Vector3(mousePos.x - rbSelf.transform.position.x, mousePos.y - rbSelf.transform.position.x);
            direction.Normalize();
            rb.velocity = new Vector2(0, 0);
            print(direction);
            rb.AddForce(-direction * shootForce);
            player.GetComponent<Ammo>().ammo--;
        }
    }
    private void Fire()
    {
        Instantiate(bullet, spawnLocation.position, spawnLocation.rotation);
    }
}
