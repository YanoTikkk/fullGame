using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private int maxHealt = 5;

    public UnityEvent eventOnTakeDamage;
    public UnityEvent eventOnHealthTake;
    public UnityEvent eventDie;
    private bool invurable = false;

    private void Start()
    {
        healthUI.Setup(maxHealt);
        healthUI.DisplayHealth(health);
    }

    public void TakeDamage(int damageValue)
    {
        if (invurable == false)
        {
            health -= damageValue;
            if (health <= 0)
            {
                health = 0;
                Die();
            }
            
            invurable = true;
            Invoke("StopInvurable",1f);
            eventOnTakeDamage.Invoke();
            healthUI.DisplayHealth(health);
        }
    }

    private void StopInvurable()
    {
        invurable = false;
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;
        if (health > maxHealt)
        {
            health = maxHealt;
        }
        eventOnHealthTake.Invoke();
        healthUI.DisplayHealth(health);
    }

    private void Die()
    {
        eventDie.Invoke();
    }
}
