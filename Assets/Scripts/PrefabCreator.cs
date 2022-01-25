using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawn;

    public void Create()
    {
        Instantiate(prefab, spawn.position, spawn.rotation);
    }
}
