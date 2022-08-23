// Written by Leanne Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> monsterPrefabs;
    [SerializeField]
    private float spawnMinTime;
    [SerializeField]
    private float spawnMaxTime;

    private float nextSpawnTime;
    
    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            int randMonster = Random.Range(0, 3);
            GameObject.Instantiate(monsterPrefabs[randMonster], transform);
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }
    }
}
