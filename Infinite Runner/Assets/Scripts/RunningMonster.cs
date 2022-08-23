//Written by Leanne Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMonster : BaseMonster
{
    [SerializeField]
    private float moveLeftSpeed;
    [SerializeField]
    private float moveRightSpeed;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("AnimState", 2);
        moveSpeed = moveLeftSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Box") || collision.collider.gameObject.tag == "Monster")
        {
            SpriteRenderer renderer;
            renderer = GetComponent<SpriteRenderer>();
            if (moveSpeed == moveLeftSpeed)
            {
                moveSpeed = moveRightSpeed;
                renderer.flipX = true;
            }
            else if (moveSpeed == moveRightSpeed)
            {
                moveSpeed = moveLeftSpeed;
                renderer.flipX = false;
            }
        }

    }

}
