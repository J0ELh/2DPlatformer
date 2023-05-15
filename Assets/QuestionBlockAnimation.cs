using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockAnimation : MonoBehaviour
{
    private Collider2D head_hit;
    [SerializeField] private Transform question_block;
    [SerializeField] private LayerMask head_layer;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        head_hit = Physics2D.OverlapArea(new Vector2(question_block.position.x - 0.49f, question_block.position.y - 0.5f), 
            new Vector2(question_block.position.x + 0.49f, question_block.position.y + 0.5f), head_layer);

        if (head_hit) {
            anim.SetBool("Hit", true);
        } else {
            anim.SetBool("Hit", false);
        }

    }
}
