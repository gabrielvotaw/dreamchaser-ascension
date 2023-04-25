using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public EnemyLife enemyLive;
    public GameObject lazyBoom;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyLive.deathCount >= 1f){
            lazyBoom.gameObject.SetActive(true);

        }

    }
}
