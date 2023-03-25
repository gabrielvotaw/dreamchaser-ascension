using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    public Transform FirePosition;
    public GameObject Projectile;
    private bool direction = true;
    private enum MovementState { idle, running, jumping, falling }
    MovementState state;
    private bool FiringOnWalkAttack = false;
    private bool FiringAttack = false;
    private bool FiringOnAir = false;
    private bool isWalking = false;
    private bool isIdle = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.F)){
            Instantiate(Projectile, FirePosition.position, FirePosition.rotation);// where to spawn projectile
            if (isWalking){
                FiringOnWalkAttack = true;
            }
            else if (isIdle){
                FiringAttack = true;
            }else if (isJumping){
                FiringOnAir = true;
            }
        }else{
            FiringOnWalkAttack = false;
            FiringAttack = false;
            FiringOnAir = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && direction)
        {
            transform.Rotate(0f, 180f, 0f);
            direction = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !direction)
        {
            transform.Rotate(0f, 180f, 0f);
            direction = true;
        
        }
        UpdateAnimationState();

    }

    private void FixedUpdate() {
        HandleAttacks();
    }
    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            state = MovementState.running;
            isWalking = true;
            isIdle = false;
            isJumping = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            isWalking = true;
            isIdle = false;
            isJumping = false;
        }
        else
        {
            state = MovementState.idle;
            isWalking = false;
            isIdle = true;
            isJumping = false;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            isWalking = false;
            isIdle = false;
            isJumping = true;
        }
        else if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
            isWalking = false;
            isIdle = false;
            isJumping = true;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void HandleAttacks(){
        if(FiringOnWalkAttack)
        {
            animator.SetTrigger("FiringOnWalk");
        }
        else if (FiringAttack)
        {
            animator.SetTrigger("Firing");
        }
        else if (FiringOnAir)
        {
            animator.SetTrigger("FiringOnAir");
        }
    }

}

