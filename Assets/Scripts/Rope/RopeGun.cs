using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopesState
{
    disablet,
    fly,
    active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private Transform spawnHook;
    [SerializeField] private Transform RopeStart;
    [SerializeField] private float speed;
    [SerializeField] private float spring = 100f;
    [SerializeField] private float damper = 5f;

    private float lengthRope;
    private Rigidbody hookRigibody;
    private SpringJoint springJoint;

    private RopesState curentRopesState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }

        if (curentRopesState == RopesState.fly)
        {
            float distance = Vector3.Distance(RopeStart.transform.position, hook.transform.position);
            
            if (distance > 20f)
            {
                hook.gameObject.SetActive(false);
                curentRopesState = RopesState.disablet;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroySpring();
        }
    }

    private void Shoot()
    {
        if (springJoint)
        {
            Destroy(springJoint);
        }
        
        hook.gameObject.SetActive(true);
        hook.StopFix();
        hook.transform.position = spawnHook.position;
        hook.transform.rotation = spawnHook.rotation;
        hookRigibody = hook.GetComponent<Rigidbody>();
        hookRigibody.velocity = spawnHook.forward * speed;

        curentRopesState = RopesState.fly;
    }

    public void CreateSpring()
    {
        if (springJoint == null)
        {
            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = hookRigibody;
            springJoint.anchor = RopeStart.localPosition;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.spring = spring;
            springJoint.damper = damper;

            lengthRope = Vector3.Distance(RopeStart.transform.position, hook.transform.position);
            springJoint.maxDistance = lengthRope;

            curentRopesState = RopesState.active;
        }
    }

    public void DestroySpring()
    {
        if (springJoint)
        {
            Destroy(springJoint);
            curentRopesState = RopesState.disablet;
            hook.gameObject.SetActive(false);
        }
    }
}
