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
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        //GameObject.Instantiate(monsterPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= nextSpawnTime)
        {
            GameObject.Instantiate(monsterPrefabs[0], transform);
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }
    }
}
