using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D (Collider2D entity){
        if(entity.gameObject.CompareTag("Enemy") && (entity.gameObject.GetComponent("CrystalPower") as CrystalPower) != null){
            entity.gameObject.GetComponent<CrystalPower>().crystalUp(true);
        }
    }
    void OnTriggerExit2D(Collider2D entity){
        if(entity.gameObject.CompareTag("Enemy") && (entity.gameObject.GetComponent("CrystalPower") as CrystalPower) != null){
            entity.gameObject.GetComponent<CrystalPower>().crystalUp(false);
        }
    }
}
