﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoss : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public Transform shotPoint;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
