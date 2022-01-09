using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    
    private Rigidbody rigibody;
    private Transform playerTransform;
    private Vector3 toPlayer;

    private void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        playerTransform = FindObjectOfType<PlayerMover>().transform;
        toPlayer = (playerTransform.position - transform.position).normalized;
        rigibody.velocity = toPlayer * speed;
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.rigidbody)
        {
            if (collisionInfo.collider.GetComponent<PlayerHeath>())
            {
                Destroy(gameObject);
            }
        }
    }
}
