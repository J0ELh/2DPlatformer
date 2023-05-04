using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int maxAirJumps = 0; //number of jumps we can do once in the air
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f; //this decides how high you can jump. Making it smaller makes you jump higher for some reason

    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    private int jumpPhase; //tracks how many times we have jumped
    private float defaultGravityScale; //allows to revert back to original one

    private bool desiredJump; //do we want to jump?
    private bool onGround; //are we on the ground?


    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f; //value applied when character is on ground
    }

    // Update is called once per frame
    void Update() {
        desiredJump |= input.RetrieveJumpInput(); //uses OR operator so it remains set even in new update cycle until manually set to false
    }

    private void FixedUpdate() {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        if (onGround) {
            jumpPhase = 0;
        } 
        if (desiredJump) {
            desiredJump = false;
            JumpAction();
        }

        if (body.velocity.y > 0 ) {
            body.gravityScale = upwardMovementMultiplier; //if going up use upwardmultiplier. Otherwise use downwardMovementMultiplier
        } else if (body.velocity.y < 0){
            body.gravityScale = downwardMovementMultiplier;
        } else if (body.velocity.y == 0) {
            body.gravityScale = defaultGravityScale; //if on ground revert back to default gravity scale
        }

        body.velocity = velocity;
    }

    private void JumpAction() {
        //Debug.Log(onGround); print whether it thinks it's touching the ground
        if (onGround || jumpPhase < maxAirJumps) {
            jumpPhase += 1;
            float jumpSpeed;
            if (!onGround) //if doing air jump give bigger impulse
            {
                //Debug.Log("worked");
                jumpSpeed = Mathf.Sqrt(-2f * (Physics2D.gravity.y   *   2) * jumpHeight); //calculate jumpspeed with formula using gravity and desired height of jump
                //for doing * 2 to double impulse value
            } else
            {
                jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight); //calculate jumpspeed with formula using gravity and desired height of jump
            }
            
            if (velocity.y > 0f) {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            } 
            //else if (velocity.y < 0f) {
              //  jumpSpeed += Mathf.Abs(body.velocity.y);
            //}
            velocity.y += jumpSpeed;

        }
    }
}
    