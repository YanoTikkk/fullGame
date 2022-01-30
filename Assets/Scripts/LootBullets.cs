using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int bulletsValue = 30;
    [SerializeField] private int guneIndex;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerArmory playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();
            
            if (playerArmory)
            {
                playerArmory.AddBullets(guneIndex, bulletsValue);
                Destroy(gameObject);
            }
        }
    }
}
