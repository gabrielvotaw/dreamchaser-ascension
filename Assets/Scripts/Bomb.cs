using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public EnemyLife enemyLive;
    public GameObject lazyBoom;
    private Rigidbody2D rb; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyLive.deathCount >= 1f){
            rb.velocity = new Vector2(0f, 0f);
            gameObject.GetComponent<EnemyMovement>().speedChange(0);
            lazyBoom.gameObject.SetActive(true);
			GetComponent<Rigidbody2D>().isKinematic = true;

        }

    }
}
