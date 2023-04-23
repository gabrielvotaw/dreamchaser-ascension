using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPower : MonoBehaviour
{
    // Start is called before the first frame update
    public bool power = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(power == true){
            gameObject.GetComponent<EnemyLife>().reductionChange(0);
            gameObject.GetComponent<EnemyShooting>().shootingChange(true);
            gameObject.GetComponent<EnemyMovement>().speedChange(0);
        }
        else{
            gameObject.GetComponent<EnemyLife>().reductionChange(1);
            gameObject.GetComponent<EnemyShooting>().shootingChange(false);
            gameObject.GetComponent<EnemyMovement>().speedChange(1);
        }

    }
    public void crystalUp (bool powerOn){
        power = powerOn;
    }
    
}
