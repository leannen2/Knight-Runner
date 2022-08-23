using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("hit monster");
            Destroy(collision.gameObject);
        }
    }
}
