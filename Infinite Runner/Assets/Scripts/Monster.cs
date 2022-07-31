using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects. We can apply forces to move a rigidbody
    [SerializeField]
    private float moveLeftSpeed;
    [SerializeField]
    private float moveRightSpeed;

    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = moveLeftSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mover = new Vector3(moveSpeed, 0f, 0f);
        //rb.AddForce(mover);
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    void FixedUpdate()
    {
        //Vector3 mover = new Vector3(moveSpeed, 0f, 0f);
        //rb.AddForce(mover);
        //rb.AddForce(new Vector3(moveSpeed, 0f, 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            Debug.Log("hit");
            if (moveSpeed == moveLeftSpeed)
            {
                moveSpeed = moveRightSpeed;
            }
            else if (moveSpeed == moveRightSpeed)
            {
                moveSpeed = moveLeftSpeed;
            }
            Debug.Log(moveSpeed);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
            Debug.Log("despawn");
        }
    }

}
