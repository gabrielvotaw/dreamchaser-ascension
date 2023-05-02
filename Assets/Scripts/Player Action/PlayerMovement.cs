using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float facingX = 1f;
    [SerializeField] private float moveSpeed = 7f;
    private float moveSpeedStore;
    [SerializeField] private float jumpForce = 14f;
    public Transform FirePosition;
    public GameObject Projectile;
    public GameObject BombShot;
    private bool direction = true;
    private enum MovementState { idle, running, jumping, falling }
    MovementState state;
    private bool FiringOnWalkAttack = false;
    private bool FiringAttack = false;
    private bool FiringOnAir = false;
    private bool isWalking = false;
    private bool isIdle = false;
    private bool isJumping = false;
    private float stayDown = 0f;
    public float KnockBackForce = 30;
    public float KnockBackUp = 30;
    public float stunCounter;
    public float stunCounterMax;
    public float gunCounter;
    public float gunCounterMax;
    public float bombCounter;
    public float bombCounterMax;
    public float bladeCounter;
    public float bladeCounterMax;
    

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource bulletSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        stunCounter = stunCounterMax;
        gunCounter = gunCounterMax;
        bombCounter = bombCounterMax;
        bladeCounter = bladeCounterMax;
        moveSpeedStore = moveSpeed;
    }

    // Update is called once per frame
    private void Update()
    {  
        if(dirX > 0f){
            facingX = -1;
        }else if(dirX < 0f){
            facingX = 1;
        }
        
        if(stunCounter < stunCounterMax){
            stunCounter++;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.LeftArrow) && stunCounter >= stunCounterMax){
            rb.velocity = new Vector2(moveSpeed * -1, rb.velocity.y);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) && stunCounter >= stunCounterMax){
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && stunCounter >= stunCounterMax){
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow) && stunCounter >= stunCounterMax){
            rb.velocity = new Vector2(0f, rb.velocity.y);
            
        }
        else if(stunCounter >= stunCounterMax & IsGrounded()){
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        
        
        //rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           jumpSoundEffect.Play();
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(gunCounter <= gunCounterMax){
            gunCounter++;
        }
        if(bombCounter <= bombCounterMax){
            bombCounter++;
        }
        if(bladeCounter <= bladeCounterMax){
            bladeCounter++;
        }
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F)){
            
            if (gunCounter > gunCounterMax){
                gunCounter = 0;
                bulletSoundEffect.Play();
                Instantiate(Projectile, FirePosition.position, FirePosition.rotation);// where to spawn projectile
                rb.velocity = new Vector2(1.5f * facingX, rb.velocity.y);
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
        }
        if(Input.GetKey(KeyCode.D) && stunCounter >= stunCounterMax){
            if(bladeCounter > bladeCounterMax){
                bladeCounter = 0;
                stunCounter = 0;
                gameObject.GetComponent<PlayerBladeAction>().bladeSwing();
            }
        }
        if(Input.GetKey(KeyCode.S)){
            if (bombCounter > bombCounterMax){
                bombCounter = 0;
                Instantiate(BombShot, FirePosition.position, FirePosition.rotation);// where to spawn projectile
                rb.velocity = new Vector2(1.5f * facingX, rb.velocity.y);
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
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && direction && stunCounter >= stunCounterMax)
        {
            transform.Rotate(0f, 180f, 0f);
            direction = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !direction && stunCounter >= stunCounterMax)
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
    public void OnCollisionEnter2D(Collision2D entity) {
        
        if (entity.gameObject.CompareTag("Enemy")){
            
            stunCounter = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D entity) {
        
        if (entity.gameObject.CompareTag("Enemy")){
            
            stunCounter = 0;
        }
    }

    public float getFace(){
        return facingX;
    }

}

