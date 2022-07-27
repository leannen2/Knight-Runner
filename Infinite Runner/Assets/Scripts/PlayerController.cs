using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects. We can apply forces to move a rigidbody
    [SerializeField]
    private float upForce; //This is the force that we will want to apply to the rigidbody when player jumps
    [SerializeField]
    private float downForce;
    //[SerializeField]
    //private Text scoreDisplay; //This is a Unity UI Text Object that you can display the score in by setting the text field of this object.

    private int score; //An internal field to store the score in.
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = transform.up * upForce;
        }
    }
}
