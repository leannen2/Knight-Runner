using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;

    private static GameStateManager _instance;

    [SerializeField]
    private Text highScoreDisplay;


    void Start()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

    }

    public static void GameOver()
    {
        //AudioManager.instance.Play("gameover");
        SceneManager.LoadScene(0);

    }

    public static void Restart()
    {
        SceneManager.LoadScene("GameScreen");
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
    
    public static void TogglePause(GameObject pauseScreen)
    {
        if (Time.timeScale == 0)
        {
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        } 
        else
        {
            Time.timeScale = 0;
            pauseScreen.gameObject.SetActive(true);
        }
        
    }
}
