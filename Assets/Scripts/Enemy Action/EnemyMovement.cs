using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    
    public float chasing = 4;
    public float chasingStore;
    public float speed;
    public float speedStore;
    public float speedMod = 1;
    private float stunTimer;
    
    private float distance;

    public float KnockBackForce;
    public float KnockBackUp;
    public float KnockDirect = 1;
    private Rigidbody2D rb;
    public GameObject playerFace;
    public EnemyLife enemyLive;
    public bool checkBool;
    public float checkFloat;
    
    // Start is called before the first frame update
    void Start()
    {
        speedStore = speed;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, playerFace.transform.position);
        Vector2 direction = playerFace.transform.position - transform.position;
        Vector2 playerExe = new Vector2(playerFace.transform.position.x, transform.position.y);

        if(speed == 0 && speedStore != 0){
            stunTimer += Time.deltaTime;
            if(stunTimer > 0.5f){
                stunTimer = 0;
                speed = speedStore;
            }
        }

        if(enemyLive.CurrentHealth != enemyLive.MaxHealth){
            chasing = chasingStore;
        }
        if(ClosePlayer() == true){
            transform.position = Vector2.MoveTowards(this.transform.position, playerExe, speed * speedMod * Time.deltaTime);
        }
        checkBool = ClosePlayer();
        checkFloat = distance;
        directionFace(playerFace);
    }
    public bool ClosePlayer(){
        return (distance < chasing);
    }
    public void speedChange(float mod){
        speedMod = mod;
    }
    public void directionFace(GameObject entity){
        if(entity.transform.position.x >= transform.position.x){
            KnockDirect = -1;
        }
        else{
            KnockDirect = 1;
        }
    }
    public Vector2 hitKnock(){
        speed = 0;
        return new Vector2(KnockBackForce * KnockDirect, KnockBackUp);
    }
}
