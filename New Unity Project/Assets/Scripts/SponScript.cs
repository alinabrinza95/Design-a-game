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
