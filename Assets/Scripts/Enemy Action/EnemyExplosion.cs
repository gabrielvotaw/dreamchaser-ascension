using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public int contactDamage;
    public GameObject playerFace;
    
    
    public float playerKnockBackForce;
    public float playerKnockBackUp;
    public GameObject enemySelf;

    
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
          entity.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerKnockBackForce*-enemySelf.gameObject.GetComponent<EnemyMovement>().KnockDirect, playerKnockBackUp);

      }
    }
}
