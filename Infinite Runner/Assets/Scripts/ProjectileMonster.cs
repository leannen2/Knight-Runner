using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMonster : BaseMonster
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float spawnMinTime;
    [SerializeField]
    private float spawnMaxTime;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            GameObject.Instantiate(projectilePrefab, transform);
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }
    }
}
