using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaCollide : MonoBehaviour
{
    [SerializeField] private LayerMask goomba_layer;
    [SerializeField] private Destroy destroy;

    void OnCollisionEnter2D(Collision2D col) {
        if (1 << col.gameObject.layer == goomba_layer) {
            destroy.OnDeath();
        }
    }
}
