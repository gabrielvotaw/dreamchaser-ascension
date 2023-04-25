using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    public int contactDamage;
    public GameObject playerFace;
    
    
    public float playerKnockBackForce;
    public float playerKnockBackUp;
    public EnemyMovement enemyMove;
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
          entity.gameObject.GetComponent<PlayerHPManager>().damagePlayer(contactDamage);
          entity.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerKnockBackForce*-enemyMove.KnockDirect, playerKnockBackUp);

      }
  }
    public void damageOff(){
      contactDamage = 0;
      playerKnockBackForce = 0;
      playerKnockBackUp = 0;

    }
}
