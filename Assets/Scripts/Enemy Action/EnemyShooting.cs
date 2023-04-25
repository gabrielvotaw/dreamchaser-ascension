using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public EnemyMovement enemyMove;

    private float fireCount;
    public float fireTimer;
    public float reloadCount;
    public int ammoCount;
    public int ammoMax;
    public float reloadTimer;
    public bool outAmmo = false;

    public bool shootOn = true;
    public bool bounceMode = false;
    public float KnockBackForceStore;

    // Start is called before the first frame update
    void Start()
    {
        KnockBackForceStore = enemyMove.KnockBackForce;
    }

    // Update is called once per frame
    void Update()
    {
        fireCount += Time.deltaTime;
        reloadCount += Time.deltaTime;
        if(bounceMode == false){
            if(fireCount > fireTimer && GetComponent<EnemyMovement>().ClosePlayer() && shootOn && !outAmmo){
                fireCount = 0;
                ammoCount++;
                shoot();
            }
            if(ammoCount > ammoMax && !outAmmo){
                outAmmo = true;
                reloadCount = 0;
            }
            if(reloadCount > reloadTimer && outAmmo){
                ammoCount = 0;
                outAmmo = false;
            }
        }
        else{
            if(GetComponent<EnemyMovement>().ClosePlayer()){
                enemyMove.KnockBackForce = KnockBackForceStore;
            }
            else{
                enemyMove.KnockBackForce = 0;
            }
            if(fireCount > fireTimer  && shootOn && !outAmmo){
                fireCount = 0;
                ammoCount++;
                shoot();
            }
            if(ammoCount > ammoMax && !outAmmo){
                outAmmo = true;
                reloadCount = 0;
            }
            if(reloadCount > reloadTimer && outAmmo){
                ammoCount = 0;
                outAmmo = false;
            }
        }
        
        void shoot(){
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
    public void shootingChange(bool onIt){
        shootOn = onIt;
    }
}
