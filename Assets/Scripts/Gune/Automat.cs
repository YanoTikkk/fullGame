using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gune
{
    [SerializeField] private int numberBullets;
    [SerializeField] private Text textNumberBullets;
    [SerializeField] private PlayerArmory playerArmory;

    public override void Shot()
    {
        base.Shot();
        numberBullets--;
        UpdateText();
        if (numberBullets == 0)
        {
            playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        textNumberBullets.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        textNumberBullets.enabled = false;
    }

    public override void AddBullets(int numbersOfBullets)
    {
        numberBullets += numbersOfBullets;
        UpdateText();
        playerArmory.TakeGunByIndex(1);
    }

    private void UpdateText()
    {
        textNumberBullets.text = "Bullets: " + numberBullets.ToString();
    }
}
