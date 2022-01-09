using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
   [SerializeField] private Renderer[] renderers;

   public void StartBlink()
   {
      StartCoroutine(BlinkEffects());
   }

   private IEnumerator BlinkEffects()
   {
      for (float t = 0; t < 1; t += Time.deltaTime)
      {
         for (int i = 0; i < renderers.Length; i++)
         {
            renderers[i].material.SetColor("_EmissionColor",new Color(Mathf.Sin(t * 30f) * 0.5f + 0.5f,0,0,0));
         }
         yield return null;
      }
   }
}
