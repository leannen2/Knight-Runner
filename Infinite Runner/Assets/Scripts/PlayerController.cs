using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects. We can apply forces to move a rigidbody
    [SerializeField]
    private float upForce; //This is the force that we will want to apply to the rigidbody
    [SerializeField]
    private float downForce;
    [SerializeField]
    private Text scoreDisplay; //This is a Unity UI Text Object that you can display the score in by setting the text field of this object.

    private int score; //An internal field to store the score in.

    private bool Pause;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        Pause = false;

        upForce = 5;

        downForce = 5;


        //Here is where you should initalize fields.
    }

    // Update is called once per frame
    void Update()
    {

        //Detect if the key is pressed down.
        if(Input.GetKeyDown(KeyCode.W))
            {
                //jump
                rb.velocity = Vector2.up * upForce * 3;
            }
            //Detect if the key is pressed down.
        if (Input.GetKeyDown(KeyCode.S))
            {
                //Dash
                rb.velocity = Vector2.down * downForce * 3;
            }
        if (Input.GetKeyDown(KeyCode.P))
            {
                
            }
        if (Input.GetMouseButtonDown(0))
            {
                //attack function
            }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //This function gets called when the collider on this object comes in contact with another collider.

        //If the player runs into a pillar object we want to end the game.
        if(collision.gameObject.tag == "Monster")
        {
            //GameStateManager.GameOver();
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //score = score +1;
        //scoreDisplay.text = score.ToString();

        //This method gets called when this object collides with another object that has it's collider set to "trigger" mode.

        //If the player enters a score trigger we want to increase the score and update the score display

        //If the player falls out of the world we want to end the game.
            //GameStateManager.GameOver();
       
    }
}
