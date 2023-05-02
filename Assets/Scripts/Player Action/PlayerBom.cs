using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBom : MonoBehaviour
{
    public int contactDamage;
    public int damageGive;
    public GameObject playerFace;
    public float KnockDirect = 1;
    
    public float playerKnockBackForce;
    public float playerKnockBackUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D entity) {
      Debug.Log("Damage touched");
      if (entity.gameObject.CompareTag("Player")){
            entity.gameObject.GetComponent<PlayerHPManager>().damagePlayer(contactDamage);
            entity.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerKnockBackForce*KnockDirect, playerKnockBackUp);

      }

      if (entity.tag == "Enemy"){
			if(entity.tag == "Enemy"){
				entity.gameObject.GetComponent<EnemyLife>().HurtEnemy(damageGive);
				
			}
			
		} 
    }
    
    
}
