using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigibody;
    [SerializeField] private float speed;
    [SerializeField] private Transform spawn;
    [SerializeField] private Gune pistol;
    [SerializeField] private float maxCharge = 3f;
    [SerializeField] private ChargeIcon chargeIcon;

    private float curentCharge;
    private bool isCharge = true;

    private void Update()
    {
        Shot();
    }

    private void Shot()
    {
        if (isCharge)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRigibody.AddForce(-spawn.forward * speed, ForceMode.VelocityChange);
                pistol.Shot();
                isCharge = false;
                curentCharge = 0f;
                chargeIcon.StartCharge();
            }
        }
        else
        {
            curentCharge += Time.unscaledDeltaTime;
            chargeIcon.SetChargeValue(curentCharge,maxCharge);
            if (curentCharge >= maxCharge)
            {
                isCharge = true;
                chargeIcon.StopCharge();
            }
        }
    }
}
