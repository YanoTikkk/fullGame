using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float inputHorizontal;
    private bool grounded;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float speedPosition = 5f;
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            playerRigidbody.AddForce(new Vector3(0f,jumpSpeed,0f));
        }
    }

    private void Mover()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        playerRigidbody.AddForce(new Vector3(inputHorizontal,0f,0f) * speedPosition,ForceMode.Acceleration);
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
       // float angle = Vector3.Angle(IEdgeConnectorListene)
        grounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }
}
