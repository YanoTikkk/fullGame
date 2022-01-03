using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gune : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotDelay;

    private float timerSpawn;

    private void Update()
    {
        timerSpawn += Time.deltaTime;

        if (timerSpawn > shotDelay & Input.GetMouseButton(0))
        {
            timerSpawn = 0f;
            GameObject newBullets = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
            newBullets.GetComponent<Rigidbody>().velocity = spawnBullet.forward * bulletSpeed;
        }
    }
}
