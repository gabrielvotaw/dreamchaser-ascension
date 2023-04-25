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
    public float deathTime;
    public float deathCount;
    public int cheapKnock = 1;
    public int cheapKnockStore;
    private bool deathDelay = false;
    public Color deathFlash = Color.grey;
    

    
    void Start()
    {
        CurrentHealth = MaxHealth;
        cheapKnockStore = cheapKnock;
        healthBar.SetHealth(CurrentHealth, MaxHealth);
        rb = GetComponent<Rigidbody2D>();

        if((gameObject.GetComponent("Bomb") as Bomb) != null){
            deathTime = 1.5f;
        }
        else if((gameObject.GetComponent("EnemyMovement") as EnemyMovement) != null){
            deathTime = 0.75f;
        }
        else{
            deathTime = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(CurrentHealth <= 0){
            if(deathDelay = true){
                Instantiate(deathBurst, transform.position, transform.rotation);
                deathBurst.gameObject.SetActive(false);
                StartCoroutine(VisualIndicator(deathFlash));
                if((gameObject.GetComponent("EnemyContactDamage") as EnemyContactDamage) != null){
                    gameObject.GetComponent<EnemyContactDamage>().damageOff();
                }
            }
            
            deathDelay = true;
            deathCount += Time.deltaTime;
        }
        if(deathCount >= deathTime){
            gameObject.SetActive(false);
        }
    }
    public void HurtEnemy(int damageGive){
        CurrentHealth -= (int) Mathf.Round(damageGive * damageReduction);
        healthBar.SetHealth(CurrentHealth, MaxHealth);
		Instantiate(bloodBurst, transform.position, transform.rotation);
        if((gameObject.GetComponent("EnemyMovement") as EnemyMovement) != null){
            if(damageGive > 0 && cheapKnock == -1){
                cheapKnock = 1;
            }
            rb.velocity = new Vector2(gameObject.GetComponent<EnemyMovement>().hitKnock().x * cheapKnock, gameObject.GetComponent<EnemyMovement>().hitKnock().y);
            cheapKnock = cheapKnockStore;
        }
        
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        
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
