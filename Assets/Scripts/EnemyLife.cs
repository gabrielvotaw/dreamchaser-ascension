using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private int health;

    void Start()
    {
=======
    public int MaxHealth;
    public int CurrentHealth;
    private Rigidbody2D rb;
    public float KnockBackForce;
    public float KnockBackUp;
    public float KnockDirect = 1;
    public GameObject playerFace;
    public GameObject bloodBurst;
    public GameObject deathBurst;
    public float chasing = 4;
    public float speed;

    private float distance;

    void Start()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        if(CurrentHealth <= 0){
            Instantiate(deathBurst, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        distance = Vector2.Distance(transform.position, playerFace.transform.position);
        Vector2 direction = playerFace.transform.position - transform.position;

        if(CurrentHealth != MaxHealth){
            chasing = 7;
        }
        if(distance < chasing){
            transform.position = Vector2.MoveTowards(this.transform.position, playerFace.transform.position, speed * Time.deltaTime);
        }
        directionFace(playerFace);
    }

    public void HurtEnemy(int damageGive){
        CurrentHealth -= damageGive;
		Instantiate(bloodBurst, transform.position, transform.rotation);
        rb.velocity = new Vector2(KnockBackForce * KnockDirect, KnockBackUp);
    }
    public void SetMaxHealth(){
        CurrentHealth = MaxHealth;
>>>>>>> Stashed changes
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
