using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private GameObject instructionsCanvas;

    public void Awake()
    {
        gameObject.SetActive(true);
        
    }

    public void OnDestroy()
    {
    }

    public void Open()
    {
        gameObject.SetActive(true);  
    }

    public void Restart()
    {
        GameStateManager.Restart();
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        GameStateManager.TogglePause(pauseScreen);
    }

    public void OpenInstructionsCanvas()
    {
        instructionsCanvas.gameObject.SetActive(true);
    }

    public void CloseInstructionsCanvas()
    {
        instructionsCanvas.gameObject.SetActive(false);
    }

}
