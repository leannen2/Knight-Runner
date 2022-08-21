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

    [SerializeField]
    private float moveSpeed;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
            StartCoroutine(SendProjectile(pos, rotation));
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
        }
        anim.SetInteger("AnimState", 0);
    }

    IEnumerator SendProjectile(Vector3 pos, Quaternion rotation)
    {
        Debug.Log("start");
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        GameObject.Instantiate(projectilePrefab, pos, rotation);
        Debug.Log("end");
    }
}
