using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeScaler = 0.3f;
    
    private float startFixedDeltatime;
    
    private void Start()
    {
        startFixedDeltatime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = timeScaler;
        }
        else
        {
            Time.timeScale = 1f;
        }

        Time.fixedDeltaTime = startFixedDeltatime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = startFixedDeltatime;
    }
}
