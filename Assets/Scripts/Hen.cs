using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeToReachSpeed = 1f;

    private Vector3 toPlayer;
    private Vector3 force;
    private Rigidbody rigidbodyHen;
    
    private void Start()
    {
        rigidbodyHen = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        toPlayer = (playerTransform.position - transform.position).normalized; 
        force = rigidbodyHen.mass * (toPlayer * speed - rigidbodyHen.velocity) / timeToReachSpeed;
        rigidbodyHen.AddForce(force);
    }
}
