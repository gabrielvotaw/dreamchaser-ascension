using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    private Rigidbody2D rb;
    public float KnockBackForce;
    public float KnockBackUp;
    public float playerKnockBackForce;
    public float playerKnockBackUp;
    public float KnockDirect = 1;
    public GameObject playerFace;
    public GameObject bloodBurst;
    public GameObject deathBurst;
    public float chasing = 4;
    public float chasingStore;
    public float speed;
    public float speedStore;
    public int contactDamage;
    public float stunTimer;
    public bool bulletImmune;
    public EnemyHealthBar healthBar;
    public float damageReduction = 1;
    public float speedMod = 1;

    private float distance;

    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(CurrentHealth, MaxHealth);
        chasingStore = chasing;
        speedStore = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0){
            Instantiate(deathBurst, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        distance = Vector2.Distance(transform.position, playerFace.transform.position);
        Vector2 direction = playerFace.transform.position - transform.position;
        Vector2 playerExe = new Vector2(playerFace.transform.position.x, transform.position.y);
        if(CurrentHealth != MaxHealth){
            chasing = chasingStore * 2;
        }
        if(ClosePlayer() == true){
            transform.position = Vector2.MoveTowards(this.transform.position, playerExe, speed * speedMod * Time.deltaTime);
        }
        if(speed == 0 && speedStore != 0){
            stunTimer += Time.deltaTime;
            if(stunTimer > 0.5f){
                stunTimer = 0;
                speed = speedStore;
            }
        }
        directionFace(playerFace);
    }
    public bool ClosePlayer(){
        return (distance < chasing);
    }
    public void HurtEnemy(int damageGive){
        CurrentHealth -= (int) Mathf.Round(damageGive * damageReduction);
        healthBar.SetHealth(CurrentHealth, MaxHealth);
		Instantiate(bloodBurst, transform.position, transform.rotation);
        rb.velocity = new Vector2(KnockBackForce * KnockDirect, KnockBackUp);
        speed = 0;
    }
    public void SetMaxHealth(){
        CurrentHealth = MaxHealth;
    }

    public void OnCollisionEnter2D(Collision2D entity) {
        Debug.Log("Damage touched");
        if (entity.gameObject.CompareTag("Player")){
            entity.gameObject.GetComponent<PlayerHPManager>().damagePlayer(contactDamage);
            entity.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerKnockBackForce*-KnockDirect, playerKnockBackUp);

        }
    }
    public void reductionChange(int reduce){
        damageReduction = reduce; 
    }
    public bool blockBullet(){
        return bulletImmune;
    }
    public void shieldCrack(){
        bulletImmune = false;
    }
    public void speedChange(float mod){
        speedMod = mod;
    }
    public void directionFace(GameObject entity){
        if(entity.transform.position.x >= transform.position.x){
            KnockDirect = -1;
        }
        else{
            KnockDirect = 1;
        }
    }
    
    
    
}
