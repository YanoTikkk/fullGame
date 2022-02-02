using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRender : MonoBehaviour
{
   [SerializeField] private LineRenderer lineRope;
   [SerializeField] private int lineRopeCount = 10;

   public void Draw(Vector3 a, Vector3 b, float lenght)
   {
      lineRope.enabled = true;
      float interpolant = Vector3.Distance(a, b) / lenght;
      float offset = Mathf.Lerp(lenght / 2f, 0f, interpolant);

      Vector3 aDown = a + Vector3.down * offset;
      Vector3 bDown = b + Vector3.down * offset;

      lineRope.positionCount = lineRopeCount + 1;

      for (int i = 0; i < lineRopeCount + 1; i++)
      {
         lineRope.SetPosition(i,
            Bezier.GetPoint(a, aDown, b, bDown, (float)i / lineRopeCount));
      }
   }

   public void Hide()
   {
      lineRope.enabled = false;
   }
}
