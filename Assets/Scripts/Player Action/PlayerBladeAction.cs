using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBladeAction : MonoBehaviour
{
    public GameObject greatSword;
    public float bladeTimer = 1.5f;
    public float bladeCount;
    public bool bladeOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bladeOn == true){
            greatSword.gameObject.SetActive(true);
            bladeCount = bladeCount + Time.deltaTime;
        }
        if(bladeCount > bladeTimer){
            bladeOn = false;
            greatSword.gameObject.SetActive(false);
        }
    }

    public void bladeSwing(){
        bladeOn = true;
        greatSword.gameObject.GetComponent<PlayerBlade>().bladeBack();
        bladeCount = 0;
    }
}
