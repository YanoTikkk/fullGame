using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHealth : MonoBehaviour
{
    [SerializeField] private int healthValue = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHeath playerHeath = other.attachedRigidbody.GetComponent<PlayerHeath>();
            
            if (playerHeath)
            {
                playerHeath.AddHealth(healthValue);
                Destroy(gameObject);
            }
        }
    }
}
