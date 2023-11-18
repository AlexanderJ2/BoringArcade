using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawntimer : MonoBehaviour
{
    public GameObject[] vehicles;
    public bool stopSpawning = false;

    float spawnDelay=0;


	// Use this for initialization
	void Start () {
        Invoke("SpawnObject", spawnDelay);
	}
	 public void SpawnObject() {
        
        int randomIndex = Random.Range(0, vehicles.Length);
        
        Instantiate(vehicles[randomIndex], transform.position, transform.rotation);
        Invoke("SpawnObject", Random.Range(1, 3));
        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }
   
}