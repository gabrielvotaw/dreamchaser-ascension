using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0){
            gameObject.SetActive(false);
        }
    }

    public void HurtEnemy(int damageGive){
        CurrentHealth -= damageGive;
    }
    public void SetMaxHealth(){
        CurrentHealth = MaxHealth;
    }
}
