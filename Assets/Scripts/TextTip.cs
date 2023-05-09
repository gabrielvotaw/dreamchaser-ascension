using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTip : MonoBehaviour
{
    public GameObject tellMe; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D entity){
        if(entity.tag == "Player"){
            tellMe.gameObject.SetActive(true);
        } 
    }
    void OnTriggerExit2D(Collider2D entity){
        if(entity.tag == "Player"){
            tellMe.gameObject.SetActive(false);
        } 
    }
}
