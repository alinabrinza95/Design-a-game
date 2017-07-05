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
