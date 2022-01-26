using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToTargetEuler : MonoBehaviour
{
    [SerializeField] private Vector3 leftEuler;
    [SerializeField] private Vector3 rightnEuler;
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 targetEuler;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(targetEuler),Time.deltaTime * rotationSpeed);
    }

    public void RotateLeft()
    {
        targetEuler = leftEuler;
    }
    
    public void RotateRight()
    {
        targetEuler = rightnEuler;
    }
}
