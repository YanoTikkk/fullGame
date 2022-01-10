using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int damageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHeath>())
            {
                other.attachedRigidbody.GetComponent<PlayerHeath>().TakeDamage(damageValue);
            }
        }
    }
}
