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
        Debug.Log(question_block.position);
        // int i = 0;
        // while (i < animators.Length && anim != animators[i]) i++;
        // string trigger = "Hit " + (char)(i + 48 + 1);

        if (head_hit) {
            anim.SetBool("Hit", true);
        } else {
            anim.SetBool("Hit", false);
        }

    }
}
