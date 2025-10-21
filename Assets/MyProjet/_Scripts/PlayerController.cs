using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool canFly = false;


    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float flyForce = 100f;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) {
            canFly = true;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        if (canFly) { 
            rb2d.AddForce(Vector2.up * flyForce);
            
            canFly = false;
        }
    }
}
