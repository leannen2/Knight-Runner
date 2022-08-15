using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreContainer : MonoBehaviour
{
    [SerializeField]
    private Text highScoreDisplay;
    void Start()
    {
        highScoreDisplay.text = ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
