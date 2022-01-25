using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggetEverySeconds : MonoBehaviour
{
    [SerializeField] private float period = 7f;
    [SerializeField] private Animator animatior;
    [SerializeField] private string triggerName = "Attack";
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > period)
        {
            timer = 0f;
            animatior.SetTrigger(triggerName);
        }
    }
}
