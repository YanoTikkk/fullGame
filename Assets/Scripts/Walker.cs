using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform targetA;
    [SerializeField] private Transform targetB;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float stopTime = 5f;
    [SerializeField] private Direction curentDirection;
    [SerializeField] private UnityEvent eventOnLeftTarget;
    [SerializeField] private UnityEvent eventOnRightTarget;
    [SerializeField]private Transform rayStart;
    
    private bool isStoped;

    private void Start()
    {
        targetA.parent = null;
        targetB.parent = null;
    }

    private void Update()
    {
        if (isStoped == false)
        {
            Walk();
        }
    }

    private void ContinueWalk()
    {
        isStoped = false;
    }

    private void Walk()
    {
        if (curentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (transform.position.x < targetA.position.x)
            {
                curentDirection = Direction.Right;
                isStoped = true;
                Invoke(nameof(ContinueWalk),stopTime);
                eventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (transform.position.x > targetB.position.x)
            {
                curentDirection = Direction.Left;
                isStoped = true;
                Invoke(nameof(ContinueWalk),stopTime);
                eventOnRightTarget.Invoke();
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(rayStart.position,Vector3.down,out hit))
        {
            transform.position = hit.point;
        }
    }
}
