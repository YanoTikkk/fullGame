using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Transform aim;

    private Ray ray;
    private Plane plane;
    private float distance;

    private void LateUpdate()
    {
        ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        plane = new Plane(-Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        aim.position = point;

        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
