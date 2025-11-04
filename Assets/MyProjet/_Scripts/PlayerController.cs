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
    [SerializeField] private float maxFallAngele = -90f;
    [SerializeField] private float rotFactor = 3f;
   


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            canFly = true;
        }
    }

    private void FixedUpdate()
    {
        //Movimentação Horizontal
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        //Aplicação d0o Voo
        if (canFly) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            rb2d.AddForce(Vector2.up * flyForce);
            
            canFly = false;
        }

        if (rb2d.velocity.y > 0f) 
        { 
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else
        {
            float _angle = Mathf.Lerp(0, maxFallAngele, -rb2d.velocity.y / rotFactor);
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
    }
}
