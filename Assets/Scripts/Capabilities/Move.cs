using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 16f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration =  90f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f; 

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

    [SerializeField] private TMPro.TextMeshProUGUI score_text;
    private Animator anim;
    [SerializeField] private Transform head_check;
    [SerializeField] private LayerMask feet_layer;
    [SerializeField] private Rigidbody2D mario;
    [SerializeField] private int bounce_power;
    private Collider2D stomped;
    private bool dead = false;
    [SerializeField] private int score_increment;
    private bool score_incrememnted = false;
    [SerializeField] private float despawn_cd = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);

        stomped = Physics2D.OverlapArea(new Vector2(head_check.position.x - 0.4f, head_check.position.y - 0.1f), new Vector2(head_check.position.x + 0.4f, head_check.position.y + 0.1f), feet_layer);
        if (stomped) {
            dead = true;
            anim.SetTrigger("Stomped");
            mario.velocity = new Vector2(mario.velocity.x, bounce_power);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<EdgeCollider2D>());
            Destroy(gameObject, despawn_cd);

            if (!score_incrememnted) {
                int score_i = System.Int32.Parse(score_text.text) + score_increment;
                score_text.text = score_i.ToString();
                score_text.text.PadLeft(6, '0');
                score_incrememnted = true;
            }
        }

        
    }

    private void FixedUpdate() {
        if (dead) return;

        onGround = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;

    }
}
