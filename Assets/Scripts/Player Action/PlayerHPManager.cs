using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public float KnockBackForce = 30;
    public float KnockBackUp = 30;
    public int immune = 1;
    private Rigidbody2D playerRB;

    // Player Respawning
    private PlayerRespawn playerRespawn;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        //player respawn
        playerRespawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            gameObject.SetActive(false);
            currentHealth = maxHealth;
            gameObject.SetActive(true);
            StartCoroutine(VisualIndicator(Color.white));
            playerRespawn.RespawnNow();

        }
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }

    }
    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        immune = 0;
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
        immune = 1;
        
    }

    public void damagePlayer(int damage){
        
        damage = damage * immune;
        currentHealth -= damage;
        if(damage != 0){
            StartCoroutine(VisualIndicator(Color.red));
        }
    }
    public void SetMaxHealth(){
        currentHealth = maxHealth;
    }

    
    
    

}
