using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombExplode : MonoBehaviour
{
    public float bulletSpeed;
	private Rigidbody2D rigidbody2d;
	private SpriteRenderer spriteRend;
	public int damageGive;
    public float projectileTimer;
    public float projectileTime; 
    public GameObject lazyBoom;
	public Color vanish;
	
	
	
	//private GameObject parent;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody2d = GetComponent<Rigidbody2D>();
		rigidbody2d.velocity = transform.right * bulletSpeed;
		spriteRend = GetComponent<SpriteRenderer>();
		//parent = GetComponent<GameObject>();
    }
	void Update(){
		projectileTimer += Time.deltaTime;
        if(projectileTimer > projectileTime - 0.5){
			rigidbody2d.velocity = new Vector2(0f, 0f);
			spriteRend.color = vanish;
			GetComponent<Rigidbody2D>().isKinematic = true;
            lazyBoom.gameObject.SetActive(true);

        }
        if(projectileTimer > projectileTime){
            Destroy(gameObject);
        }
        
    }
    private void OnBecameVisible()
	{
		
	
	}

	

	private void Destroy()
	{
		gameObject.SetActive(false);
	}

	

	private void OnTriggerEnter2D(Collider2D entity) {
		
		if (entity.tag == "Enemy"){
			
			projectileTimer = projectileTime - 1f;
			
		} 
	}
}
