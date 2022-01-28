using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private Image foreGround;
    [SerializeField] private Text reloadTime;

    public void StartCharge()
    {
        backGround.color = new Color(1f, 1f, 1f, 0.2f);
        foreGround.enabled = true;
        reloadTime.enabled = true;
    }

    public void StopCharge()
    {
        backGround.color = new Color(1f, 1f, 1f, 1f);
        foreGround.enabled = false;
        reloadTime.enabled = false;
    }

    public void SetChargeValue(float curentCharge,float maxCharge)
    {
        foreGround.fillAmount = curentCharge / maxCharge;
        reloadTime.text = Mathf.Ceil(maxCharge - curentCharge).ToString();
    }
}
