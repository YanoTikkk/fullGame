using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5f;
    
    private void Start()
    {
        Destroy(gameObject,destroyTime);
    }
}
