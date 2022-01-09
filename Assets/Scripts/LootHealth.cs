using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHealth : MonoBehaviour
{
    [SerializeField] private int healthValue = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHeath>())
        {
            other.attachedRigidbody.GetComponent<PlayerHeath>().AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
