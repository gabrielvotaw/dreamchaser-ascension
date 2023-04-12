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
    // Start is called before the first frame update
    void Start()
    {
        
        
        playerRB = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        Debug.Log("Damage started");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            gameObject.SetActive(false);
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
        Debug.Log(KnockBackForce);
        currentHealth -= damage;
        if(damage != 0){
            StartCoroutine(VisualIndicator(Color.red));
        }
        Debug.Log("Damage taken");
    }
    public void SetMaxHealth(){
        currentHealth = maxHealth;
        Debug.Log("Damage restored");
    }

    public void OnCollisionEnter2D(Collision2D entity) {
        Debug.Log("Damage touched");
        if (entity.gameObject.CompareTag("Enemy")){
            damagePlayer(20);

        }
    }
    
    

}
