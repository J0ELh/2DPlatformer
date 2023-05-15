using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private bool facingRight;
    private bool grounded;

    public float speed = 10;
    public float jump_power = 8;

    public Rigidbody2D rb;
    public Transform grounded_check;
    public LayerMask ground_layer;



    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        grounded = Physics2D.OverlapCircle(grounded_check.position, 0.4f, ground_layer);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rb.velocity = new Vector2(rb.velocity.x, jump_power);
        }

    }

    void FixedUpdate() {
        rb.velocity = new Vector2(speed * horizontalInput, rb.velocity.y);
    }
}
