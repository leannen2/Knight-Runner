using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects. We can apply forces to move a rigidbody

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    

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
