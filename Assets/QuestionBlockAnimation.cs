using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockAnimation : MonoBehaviour
{
    private Collider2D head_hit;
    [SerializeField] private Transform head_transform;
    [SerializeField] private LayerMask ground_layer;
    [SerializeField] private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        head_hit = Physics2D.OverlapArea(new Vector2(head_transform.position.x - 0.49f, head_transform.position.y - 0.5f), 
            new Vector2(head_transform.position.x + 0.49f, head_transform.position.y + 0.5f), ground_layer);
        
        if (head_hit && head_hit.gameObject.tag == "Question Block")
            anim.SetTrigger("Hit");
            
    }
}
