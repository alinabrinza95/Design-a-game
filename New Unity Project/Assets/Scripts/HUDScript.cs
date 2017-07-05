using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HUD=Heads of Display
public class HUDScript : MonoBehaviour {

    float playerScore = 0;

	
	// Update is called once per frame
	void Update () {
        //the scores get higher by the time spent alive in the game
        playerScore += Time.deltaTime;
	}
    //for bonus points beside those for staying alive in the game for a number of seconds
    public void increaseScore(int amount)
    {
        playerScore += amount;
    }

    //when the player gets from a level to another
    //it remembers the gained points
    //allows to pass the score through the next scenes
    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)playerScore);
    }
    //the number of points gained by the time spent in the game
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 300), "Score: " + (int)(playerScore * 100));

    }
}
