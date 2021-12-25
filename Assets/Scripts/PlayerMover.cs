using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float inputHorizontal;
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        playerRigidbody.AddForce(new Vector3(inputHorizontal,0f,0f),ForceMode.Acceleration);
    }
}
