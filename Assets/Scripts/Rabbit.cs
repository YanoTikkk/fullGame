using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private float attackPeriod = 7f;
    [SerializeField] private Animator animatior;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackPeriod)
        {
            timer = 0f;
            animatior.SetTrigger("Attack");
        }
    }
}
