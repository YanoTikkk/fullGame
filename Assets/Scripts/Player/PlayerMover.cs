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
    [SerializeField] private Transform ColiderTransform;
    [SerializeField] private float speedPosition = 5f;
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ScaleColider();
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

    private void ScaleColider()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || grounded == false )
        {
            ColiderTransform.localScale = Vector3.Lerp(ColiderTransform.localScale, new Vector3(1f, 0.5f, 1f),
                Time.deltaTime * 13f);
        }
        else
        {
            ColiderTransform.localScale = Vector3.Lerp(ColiderTransform.localScale, new Vector3(1f, 1f, 1f),
                Time.deltaTime * 13f);
        }
    }

    private void Mover()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        playerRigidbody.AddForce(inputHorizontal * speedPosition,0f,0f,ForceMode.Acceleration);
        playerRigidbody.AddForce(-playerRigidbody.velocity.x,0f,0f,ForceMode.Acceleration);
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        float angle = Vector3.Angle(collisionInfo.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }
}
