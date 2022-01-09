using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealt;
    [SerializeField] private bool DieOnCollision = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullets>())
            {
                enemyHealt.TakeDamage(1);
            }
        }

        if (DieOnCollision == true)
        {
            enemyHealt.TakeDamage(999);
        }
    }
}
