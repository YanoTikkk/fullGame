using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,target.position,Time.deltaTime * 5f);
    }
}
