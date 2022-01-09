using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGlow : MonoBehaviour
{
    [SerializeField] private Image damageImage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {
        damageImage.enabled = true;
        for (float t = 1; t > 0f; t -= Time.deltaTime * 2f)
        {
            damageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }
        damageImage.enabled = false;
    }
}
