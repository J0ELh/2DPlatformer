using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{

    private const float STATIONARY_DELTA = 0.01f;
    public Rigidbody2D rb;
    public Animator anim;

    public Transform grounded_check;
    public LayerMask ground_layer;
    bool is_grounded;

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics2D.OverlapCircle(grounded_check.position, 0.2f, ground_layer);

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) {
            anim.SetBool("is_grounded", false);
        }

        if (!anim.GetBool("is_grounded") && is_grounded) {
            anim.SetBool("is_grounded", true);
        }


        if (Input.GetKey(KeyCode.A)) {
            anim.SetBool("running_left", true);
            anim.SetBool("running_right", false);
        }

        if (Input.GetKey(KeyCode.D)) {
            anim.SetBool("running_right", true);
            anim.SetBool("running_left", false);
        }

        bool stationary = rb.velocity.x < STATIONARY_DELTA && rb.velocity.x > -STATIONARY_DELTA;
        if (stationary) {
            anim.SetBool("running_right", false);
            anim.SetBool("running_left", false);
        }





    }
}