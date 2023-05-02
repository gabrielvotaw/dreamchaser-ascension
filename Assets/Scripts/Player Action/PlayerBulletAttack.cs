using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletAttack : MonoBehaviour
{
    public Transform FirePosition;
    public GameObject Projectile;

    [SerializeField] private AudioSource bulletSoundEffect;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            bulletSoundEffect.Play();
            Instantiate(Projectile, FirePosition.position, FirePosition.rotation);// where to spawn projectile
        }
    }
}
