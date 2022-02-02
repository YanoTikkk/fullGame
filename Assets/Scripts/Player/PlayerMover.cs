using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform ColiderTransform;
    [SerializeField] private float speedPosition = 5f;
    [SerializeField] private float friction = 5f;
    [SerializeField] private float maxSpeed;

    private int jumpFrameCounter;
    private Rigidbody playerRigidbody;
    private float inputHorizontal;
    private bool grounded;

    public bool Grounded => grounded;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ScaleColider();
        
        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Mover();

        jumpFrameCounter++;
        
        if (jumpFrameCounter == 2)
        {
            playerRigidbody.freezeRotation = false;
            playerRigidbody.AddRelativeTorque(0,0,10f,ForceMode.VelocityChange);
        }
    }

    public void Jump()
    {
        playerRigidbody.AddForce(0f, jumpSpeed,0f, ForceMode.VelocityChange);
        jumpFrameCounter = 0;
    }

    private void ScaleColider()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || grounded == false )
        {
            ColiderTransform.localScale = Vector3.Lerp(ColiderTransform.localScale, new Vector3(1f, 0.7f, 1f),
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
        float speedMultiplayer = 1f;
        
        if (grounded == false)
        {
            speedMultiplayer = 0.2f;
        }

        if (playerRigidbody.velocity.x > maxSpeed && Input.GetAxis("Horizontal") > 0)
        {
            speedMultiplayer = 0;
        }
        if (playerRigidbody.velocity.x < -maxSpeed && Input.GetAxis("Horizontal") < 0)
        {
            speedMultiplayer = 0;
        }
        
        playerRigidbody.AddForce(Input.GetAxis("Horizontal") * speedPosition * speedMultiplayer,0f,0f,ForceMode.VelocityChange);
        
        if (grounded)
        {
            playerRigidbody.AddForce(-playerRigidbody.velocity.x * friction,0f,0f,ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.identity, Time.deltaTime * 15f);
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        float angle = Vector3.Angle(collisionInfo.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            grounded = true;
            playerRigidbody.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }
}
