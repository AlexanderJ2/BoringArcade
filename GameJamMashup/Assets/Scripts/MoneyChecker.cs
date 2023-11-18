using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IncomeDurability : MonoBehaviour
{

        public int Money = 0;
        public int Durability=100;

        // public BoxCollider collider; 
        
    // Start is called before the first frame update
    // void Start()
    // {
  
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
     void OnTriggerEnter(Collider other){

         if (other.CompareTag("Car")){
            Money += 1;
            Durability -= 1;
        }
    }
}
