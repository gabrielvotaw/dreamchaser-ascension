using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D entity) {
        if (entity.gameObject.CompareTag("Player")){
            GetComponent<EnemyLife>().HurtEnemy(100000);
        }
    }
}
