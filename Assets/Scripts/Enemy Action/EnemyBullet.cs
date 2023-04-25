using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float projectileTimer;
    public float projectileTime; 
    public int contactDamage;
    public float KnockBackForce;
    public float KnockBackUp;
    public float KnockDirect = 1;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update(){
        projectileTimer += Time.deltaTime;
        if(projectileTimer > projectileTime){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D entity) {
		
		if (entity.gameObject.CompareTag("Player")){
            entity.gameObject.GetComponent<PlayerHPManager>().damagePlayer(contactDamage);
            entity.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(KnockBackForce*-KnockDirect, KnockBackUp);
            Destroy(gameObject);
        }
            if (entity.tag == "Ground"){
            Destroy(gameObject);

        }

        }
        
        public void directionFace(GameObject entity){
        if(entity.transform.position.x >= transform.position.x){
            KnockDirect = -1;
        }
        else{
            KnockDirect = 1;
        }
    }
	}
