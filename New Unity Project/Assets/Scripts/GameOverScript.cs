using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    int score = 0;
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
    }
    void OnGUI()
    {
        //game over
        GUI.Label(new Rect(Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
        //score 
        GUI.Label(new Rect(Screen.width / 2 - 40, 300, 80, 30), "Score: " + score);
        //wanna try again?
        if (GUI.Button(new Rect(Screen.width / 2 - 30, 250, 60, 30), "Retry?"))
        {
            Application.LoadLevel(0);
        }
    }
}
