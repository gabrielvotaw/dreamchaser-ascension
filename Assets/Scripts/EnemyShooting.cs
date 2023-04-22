using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    public float fireTimer;
    public bool shootOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > fireTimer && GetComponent<EnemyLife>().ClosePlayer() && shootOn){
            timer = 0;
            shoot();
        }
        
        void shoot(){
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
    public void shootingChange(bool onIt){
        shootOn = onIt;
    }
}
