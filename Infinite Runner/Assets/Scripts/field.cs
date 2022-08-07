using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            //attack function
            gameObject.SetActive(true);
        }
        
        else
        {
            gameObject.SetActive(false);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("hit monster");
            Destroy(collision.gameObject);
        }
    }
}
