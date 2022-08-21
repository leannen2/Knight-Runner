using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects. We can apply forces to move a rigidbody

    [SerializeField]
    protected float moveSpeed;

    protected Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
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
