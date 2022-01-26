using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float distanceToActivate = 20f;
    private bool isActive = true;
    private Activator activator;

    private void Start()
    { 
        activator = FindObjectOfType<Activator>();
        activator.objectToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        
        if (isActive)
        {
            if (distance > distanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < distanceToActivate)
            {
                Activate();
            }
        }
    }
    
    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        activator.objectToActivate.Remove(this);
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position,Vector3.forward, distanceToActivate);
    }
#endif
    
}
