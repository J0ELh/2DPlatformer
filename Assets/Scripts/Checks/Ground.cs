using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    private bool OnGround;
    private float friction;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        EvaluateCollision(collision);
        // RetrieveFriction(collision);     // not sure why this is creating nullptr exception
    }

    private void OnCollisionStay2D(Collision2D collision) {
        EvaluateCollision(collision);
        // RetrieveFriction(collision);     // not sure why this is creating nullptr exception
    }

    private void OnCollisionExit2D(Collision2D collision) {
        OnGround = false;
        friction = 0;
    }

    private void EvaluateCollision(Collision2D collision) {
        for (int i = 0; i < collision.contactCount; i++) {
            Vector2 normal = collision.GetContact(i).normal;
            OnGround |= normal.y >= 0.9f; //WHAT DOES THE | DO????
        }
    }

    private void RetrieveFriction(Collision2D collision) {
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;

        friction = 0;

        if (material != null) {
            friction = material.friction;
        }
    }

    public bool GetOnGround() {
        return OnGround;
    }

public float GetFriction() {
    return friction;
}
}
