using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gune : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotDelay;
    [SerializeField] private float destroyTime = 5f;

    private float timerSpawn;

    private void Update()
    {
        timerSpawn += Time.unscaledDeltaTime;

        if (timerSpawn > shotDelay & Input.GetMouseButton(0))
        {
            timerSpawn = 0f;
            Shot();
        }
    }

    public virtual void Shot()
    {
        Rigidbody newBullets = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        newBullets.velocity = spawnBullet.forward * bulletSpeed;
        Destroy(newBullets,destroyTime);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numbersOfBullets)
    {
        
    }
}
