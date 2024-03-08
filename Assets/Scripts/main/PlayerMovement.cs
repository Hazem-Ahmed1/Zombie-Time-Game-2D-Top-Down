using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementspeed = 5;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Vector2 movement;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }


    void Update()
    {

        movement.x =  Input.GetAxisRaw("Horizontal");
        movement.y =  Input.GetAxisRaw("Vertical");

        animator.SetFloat("hInput", movement.x);
        animator.SetFloat("vInput", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementspeed * Time.fixedDeltaTime);
    }
}
