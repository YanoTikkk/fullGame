using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] public List<ActivateByDistance> objectToActivate = new List<ActivateByDistance>();
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        for (int i = 0; i < objectToActivate.Count; i++)
        {
            objectToActivate[i].CheckDistance(playerTransform.position);
        }
    }
}
