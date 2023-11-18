using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    //Car settings
    public float speed = 5f;
    Player _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter(Collision collision){
        if (collision.collider.CompareTag("CarDestroyer")){
            Destroy(gameObject);
        }
    }

}
