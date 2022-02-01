using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Collider colliderHook;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private RopeGun ropeGun;
    
    private FixedJoint fixedJoint;

    private void Start()
    {
        Physics.IgnoreCollision(colliderHook,playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (fixedJoint == null)
        {
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            
            if (collision.rigidbody)
            {
                fixedJoint.connectedBody = collision.rigidbody;
            }
            ropeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (fixedJoint)
        {
            Destroy(fixedJoint);
        }
    }
}
