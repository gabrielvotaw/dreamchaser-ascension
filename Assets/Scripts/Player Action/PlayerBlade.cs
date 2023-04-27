using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlade : MonoBehaviour
{
    
    public int damageGive;
    public bool damageOn;
	
	
	
	//private GameObject parent;

	// Start is called before the first frame update
	void Start()
    {

    }
	
	private void OnTriggerEnter2D(Collider2D entity) {
		
        if(entity.tag == "Enemy" && damageOn){
            entity.gameObject.GetComponent<EnemyLife>().HurtEnemy(damageGive);
            damageOn = false;
            if(entity.tag == "Enemy" && entity.gameObject.GetComponent<EnemyLife>().blockBullet() == true){
                entity.gameObject.GetComponent<EnemyLife>().shieldCrack();
                //A sound effect should play.
            }
        }
		
	}

    public void bladeBack(){
        damageOn = true;
    }
    
}
