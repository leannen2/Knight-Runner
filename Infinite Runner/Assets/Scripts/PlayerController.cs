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

    [Header("Score")]
    [SerializeField]
    private Text scoreDisplay; //This is a Unity UI Text Object that you can display the score in by setting the text field of this object.
    private float score; //An internal field to store the score in.

    [Header("Attack")]
    [SerializeField] private GameObject attackField;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    private Animator anim;

    private bool jump;//jumping limitation

    [Header("Pause Menu")]
    [SerializeField]
    private GameObject pauseScreen;
    private bool Pause;
    // Start is called before the first frame update
    void Awake()
    {
        attackField.SetActive(false);
        score = 0;
        scoreDisplay.text = score.ToString();

        Pause = false;

        upForce = 5;

        downForce = 5;

        anim = GetComponent<Animator>();

        jump = true;
        //Here is where you should initalize fields.
    }

    // Update is called once per frame
    void Update()
    {

        //Detect if the key is pressed down.
        if(Input.GetKeyDown(KeyCode.W))
        {
            //jump
            Jump();
        }
            //Detect if the key is pressed down.
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Dash
            rb.velocity = Vector2.down * downForce * 3;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.TogglePause(pauseScreen);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //attack function
            anim.SetTrigger("Attack");
            StartCoroutine(Attack());
        }
        
        // increases score with the amount of time that has passed since the last update
        score += Time.deltaTime;
        scoreDisplay.text = ((int)score).ToString();

    }

    // Activates the attack field and then deactivates it
    IEnumerator Attack() 
    {
        attackField.SetActive(true);
        yield return new WaitForSeconds(1);
        attackField.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //This function gets called when the collider on this object comes in contact with another collider.

        //If the player runs into a pillar object we want to end the game.
        if(collision.gameObject.tag == "Monster")
        {
            SetHighScore();
            GameStateManager.GameOver();

        }

        if(collision.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //This method gets called when this object collides with another object that has it's collider set to "trigger" mode.

        //If the player enters a score trigger we want to increase the score and update the score display

        //If the player falls out of the world we want to end the game.
            //GameStateManager.GameOver();
        // Leanne: Call Game Over when player gets pushed off the screen
        if (collision.gameObject.tag == "Despawn")
        {
            SetHighScore();
            GameStateManager.GameOver();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right*range*transform.localScale.x*colliderDistance, 
        new Vector3(boxCollider.bounds.size.x*range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, 0);
        return raycastHit.collider != null;
    }

    private void Damage()
    {
        
    }   

    private void SetHighScore()
    {
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        
    }

    private void Jump()
    {
        if(jump==true)
        {
            rb.velocity = Vector2.up * upForce * 3;
            jump = false;
        }

        else
        {
            return;
        }    
    }
}
