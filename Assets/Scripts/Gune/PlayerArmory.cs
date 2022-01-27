using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gune[] guns;
    [SerializeField] private int curentGunIndex;

    private void Start()
    {
        TakeGunByIndex(curentGunIndex);
    }

    public void TakeGunByIndex(int guneIndex)
    {
        curentGunIndex = guneIndex;

        for (int i = 0; i < guns.Length; i++)
        {
            if (i == guneIndex)
            {
                guns[i].gameObject.SetActive(true);
            }
            else
            {
                guns[i].gameObject.SetActive(false);
            }
        }
    }
}
