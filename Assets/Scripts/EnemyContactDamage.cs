using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    public int contactDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D entity) {
		
		if (entity.tag == "Player"){
			entity.gameObject.GetComponent<PlayerHPManager>().damagePlayer(contactDamage);
		}
	}
}
