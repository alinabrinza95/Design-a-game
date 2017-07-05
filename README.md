# ComputerGraphics
Game similar to Mario.
It needs to be run under Unity and the only button you have to use in order to jump and collect the squares is the space bar.
After finishing the game, the points are shown: they are calculated by the squares you got to collect and the time you stood alive in the game.
If you want to play it again, you have a button for Play again.


Apart from the template given by Unity, I added some more scripts such as:
- CameraRunnerScript.cs
- DestroyerScript.cs
- GameOverScript.cs
- HUDScript.cs
- PowerUpScript.cs
- SponScript.cs

Code of the Scripts above:

CameraRunnerScript.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunnerScript : MonoBehaviour {

    public Transform player;
	//Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x + 6, 0, -10);
	}
}

DestroyerScript.cs
	
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel(1);
            return;
        }
        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }

    }
}

GameOverScript.cs

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

HUDScript.cs

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

PowerUpScript.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for the powerUps
//reference to the HUDScript in order to increase the score
//everytime the player gets the bonus point
public class PowerUpScript : MonoBehaviour {

    HUDScript hud;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
            //if the player got the powerUp he gets 10 points
            hud.increaseScore(10);
            //the the powerUp is destroyed
            Destroy(this.gameObject);
        }
    }
	
}

SponScript.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponScript : MonoBehaviour {
    //responsible from spawning everything
    // Use this for initialization

    public GameObject[] obj;
    public float spawnMin = 1f; //one second
    public float spawnMax = 2f; //two seconds

    
	void Start () {
        Spawn();
	}
    //instantiate a random object at ar spawn object position with no rotation
    //invoke method at a random period of time
    void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
