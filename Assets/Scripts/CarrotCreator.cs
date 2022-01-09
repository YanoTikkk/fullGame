using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    [SerializeField] private GameObject CarrotPrefab;
    [SerializeField] private Transform positions;

    public void Create()
    {
        Instantiate(CarrotPrefab, positions.position, Quaternion.identity);
    }
}
