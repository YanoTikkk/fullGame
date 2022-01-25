using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealt;
    [SerializeField] private bool DieOnCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullets>())
            {
                enemyHealt.TakeDamage(1);
            }
        }

        if (DieOnCollision == true)
        {
            if (other.isTrigger == false)
            {
                enemyHealt.TakeDamage(999);
            }
        }
    }
}
