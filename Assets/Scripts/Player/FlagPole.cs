using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    [SerializeField] private GameObject mario;
    [SerializeField] private Animator anim;
    [SerializeField] private float descend_speed;
    private bool descend = false;

    void OnTriggerEnter2D(Collider2D col) {
        descend = true;
        anim.SetBool("flagpole", true);
        Destroy(mario.GetComponent<Rigidbody2D>());
        mario.transform.position = new Vector3(transform.position.x - 0.5f, mario.transform.position.y, 0);
    }

    void FixedUpdate() {
        if (descend) {
            if (mario.transform.position.y > 1.5f) {
                mario.transform.position += new Vector3(0, -Time.deltaTime * descend_speed, 0);
            } else {
                descend = false;
                anim.SetBool("game_over", true);
            }
        }
    }
}
