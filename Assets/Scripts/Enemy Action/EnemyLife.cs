using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    private Rigidbody2D rb;
    
    public GameObject playerFace;
    public GameObject bloodBurst;
    public GameObject deathBurst;
    public bool bulletImmune;
    public EnemyHealthBar healthBar;
    public float damageReduction = 1;

    
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(CurrentHealth, MaxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0){
            Instantiate(deathBurst, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        
    }
    public void HurtEnemy(int damageGive){
        CurrentHealth -= (int) Mathf.Round(damageGive * damageReduction);
        healthBar.SetHealth(CurrentHealth, MaxHealth);
		Instantiate(bloodBurst, transform.position, transform.rotation);
        if((gameObject.GetComponent("EnemyMovement") as EnemyMovement) != null){
            rb.velocity = gameObject.GetComponent<EnemyMovement>().hitKnock();
        }
        
    }
    public void SetMaxHealth(){
        CurrentHealth = MaxHealth;
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
    
    
    
    
    
}
