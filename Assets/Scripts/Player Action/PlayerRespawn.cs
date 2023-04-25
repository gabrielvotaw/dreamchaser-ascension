using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerRespawn : MonoBehaviour
{
    // just resets the level now when player dies or falls off level
    public void RespawnNow(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "DeathTrigger"){
            RespawnNow();
        }
    }

}
