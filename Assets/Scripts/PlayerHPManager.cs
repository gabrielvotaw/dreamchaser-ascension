using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Damage started");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < 0){
            gameObject.SetActive(false);
        }

    }
    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void damagePlayer(int damage){
        StartCoroutine(VisualIndicator(Color.red));
        currentHealth -= damage;
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
