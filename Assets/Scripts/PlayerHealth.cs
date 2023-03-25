using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] Healthbar _healthbar;
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;
    int damage = 10;
    public static Action OnPlayerDeath;
    public static Action OnEnemyDeath;

    // Update is called once per frame
    void Update()
    {
        //test damage and damage indicators
        /* if (Input.GetKeyDown(KeyCode.D))
        {
            Damage(damage);
        } */
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    // Damage Visual Indicators
    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        else if (health <= 0)
        {
            Die();
        }
        else{
            this.health -= amount;
        
            StartCoroutine(VisualIndicator(Color.red)); // Added for Visual Indicators
            //_healthbar.SetHealth(this.health);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        if (this.CompareTag("Player")){
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        } else {
            OnEnemyDeath?.Invoke();
        }
    }
}
