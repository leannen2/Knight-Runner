using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float spawnMinTime;
    [SerializeField]
    private float spawnMaxTime;

    private float nextSpawnTime;

    [SerializeField]
    private float moveSpeed;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        if (Time.time >= nextSpawnTime)
        {
            Vector3 pos = transform.position;
            pos += new Vector3(-0.75f, 0.5f, 0f);
            Quaternion rotation = projectilePrefab.transform.rotation;
            GameObject.Instantiate(projectilePrefab, pos, rotation);
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }
    }
}
