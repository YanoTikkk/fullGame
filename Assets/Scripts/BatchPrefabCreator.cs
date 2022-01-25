using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawn;
    
    public void Create()
    {
        foreach (var s in spawn)
        {
            Instantiate(prefab, s.position, s.rotation);
        }
    }
}
