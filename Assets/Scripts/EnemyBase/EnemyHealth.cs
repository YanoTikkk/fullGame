using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Healt;
    public UnityEvent eventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        Healt -= damageValue;
        if (Healt <= 0)
        {
            Die();
        }
        eventOnTakeDamage.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
