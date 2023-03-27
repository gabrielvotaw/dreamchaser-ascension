using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float bulletSpeed;
	private Rigidbody2D rigidbody2d;
	public int damageGive;
	public GameObject bloodBurst;

	
	//private GameObject parent;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody2d = GetComponent<Rigidbody2D>();
		//parent = GetComponent<GameObject>();
    }

	private void OnBecameVisible()
	{
		rigidbody2d.velocity = transform.right * bulletSpeed;
	}

	private void OnBecameInvisible()
	{
		Invoke("Destroy", 0.25f);
	}

	private void Destroy()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		CancelInvoke();
	}

	private void OnTriggerEnter2D(Collider2D entity) {
		
		if (entity.tag == "Enemy"){
			entity.gameObject.GetComponent<EnemyLife>().HurtEnemy(damageGive);
			Instantiate(bloodBurst, transform.position, transform.rotation);
			Destroy(gameObject);

		}
	}
}
