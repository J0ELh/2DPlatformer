using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockAnimation : MonoBehaviour
{
    private Collider2D head_hit;
    [SerializeField] private Transform question_block;
    [SerializeField] private LayerMask head_layer;
    private Animator anim;
    [SerializeField] private TMPro.TextMeshProUGUI score_text;
    [SerializeField] private int score_increment;
    private bool score_incrememnted = false;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        head_hit = Physics2D.OverlapArea(new Vector2(question_block.position.x - 0.49f, question_block.position.y - 0.5f), 
            new Vector2(question_block.position.x + 0.49f, question_block.position.y + 0.5f), head_layer);

        if (head_hit) {
            anim.SetBool("Hit", true);
            if (!score_incrememnted) {
                int score_i = System.Int32.Parse(score_text.text) + score_increment;
                score_text.text = score_i.ToString();
                score_text.text.PadLeft(6, '0');
                score_incrememnted = true;
            }
        } else {
            anim.SetBool("Hit", false);
        }

    }
}
