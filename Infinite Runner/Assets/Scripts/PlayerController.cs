using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;  
    [SerializeField]
    private float upForce; //This is the force that we will want to apply to the rigidbody
    [SerializeField]
    private float downForce;

    [Header("Score")]
    [SerializeField]
    private Text scoreDisplay;
    private float score;

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
    AudioSource audioSource;

    [Header("Pause Menu")]
    [SerializeField]
    private GameObject pauseScreen;

    [Header("Game Over")]
    [SerializeField]
    private GameObject gameOverText;
    void Awake()
    {
        attackField.SetActive(false);
        score = 0;
        scoreDisplay.text = score.ToString();

        upForce = 5;

        downForce = 5;

        anim = GetComponent<Animator>();

        jump = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.W))
        {
            //jump
            Jump();
        }

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
        if(collision.gameObject.tag == "Monster")
        {
            StartCoroutine(GameOver());


        }

        if(collision.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Despawn")
        {
            StartCoroutine(GameOver());

        }
    }
        //visual attack range
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

    IEnumerator GameOver()
    {
        audioSource.mute = !audioSource.mute;
        GetComponent<Renderer>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        AudioManager.instance.Play("gameover");
        SetHighScore();
        yield return new WaitForSeconds(3);
        GameStateManager.GameOver();
    }
}
