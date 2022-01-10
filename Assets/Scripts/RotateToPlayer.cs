using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 LeftEuler;
    [SerializeField] private Vector3 RightEuler;
    [SerializeField] private float rotationSpeed = 10f;

    private Transform playerTransform;
    private Vector3 targetEuler;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMover>().transform;
    }

    private void Update()
    {
        RotateTo();
    }

    private void RotateTo()
    {
        if (transform.position.x < playerTransform.position.x)
        {
            targetEuler = RightEuler;
        }
        else
        {
            targetEuler = LeftEuler;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(targetEuler),Time.deltaTime * rotationSpeed);
    }
}
