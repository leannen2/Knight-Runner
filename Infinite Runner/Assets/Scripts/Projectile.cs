using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger");
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
            //Debug.Log("despawn");
        }
    }
}
