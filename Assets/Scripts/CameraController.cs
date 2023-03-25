using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset = new Vector3(0, 2, -5);
    private float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private float lookAhead;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            player.position + offset,
            ref currentVelocity,
            smoothTime
            );
    }
}
