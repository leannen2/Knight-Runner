using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> groundPrefabs;
    [SerializeField]
    private float spawnTime;

    private float nextSpawnTime;
    void Start()
    {
        nextSpawnTime = Time.time + spawnTime;
        int randGround = Random.Range(0, 3);
        GameObject.Instantiate(groundPrefabs[randGround]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            int randGround = Random.Range(0, 3);
            GameObject.Instantiate(groundPrefabs[randGround]);
            nextSpawnTime = Time.time + spawnTime;
        }
    }
}
