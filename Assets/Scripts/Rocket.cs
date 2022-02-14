using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float speedPosition;
    [SerializeField] private float rotation;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMover>().transform;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speedPosition;
        Vector3 toPlayer = playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer,Vector3.forward);
        transform.position = new Vector3();

        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime * rotation);
    }
}
