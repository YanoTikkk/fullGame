using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private int maxHealt = 5;
    [SerializeField] private TMP_Text text;

    public UnityEvent eventOnTakeDamage;
    public UnityEvent eventOnHealthTake;
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
        text.color = Color.red;
        text.text = "ВЫ ПРОИГРАЛИ";
    }
}
