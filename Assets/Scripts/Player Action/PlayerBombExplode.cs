using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombExplode : MonoBehaviour
{
    public float bulletSpeed;
	private Rigidbody2D rigidbody2d;
	public int damageGive;
    public float projectileTimer;
    public float projectileTime; 
    public GameObject lazyBoom;
	
	
	
	//private GameObject parent;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody2d = GetComponent<Rigidbody2D>();
		//parent = GetComponent<GameObject>();
    }
	void Update(){
		projectileTimer += Time.deltaTime;
        if(projectileTimer > projectileTime - 0.5){
            lazyBoom.gameObject.SetActive(true);

        }
        if(projectileTimer > projectileTime){
            Destroy(gameObject);
        }
        
    }
    private void OnBecameVisible()
	{
		rigidbody2d.velocity = transform.right * bulletSpeed;
	
	}

	

	private void Destroy()
	{
		gameObject.SetActive(false);
	}

	

	private void OnTriggerEnter2D(Collider2D entity) {
		
		if (entity.tag == "Enemy"){
			
			projectileTimer = projectileTime - 0.5f;
			
		} 
	}
}
