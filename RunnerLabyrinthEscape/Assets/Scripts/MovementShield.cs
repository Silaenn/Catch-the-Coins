using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShield : MonoBehaviour
{
    private int speed = 3;
    // Update is called once per frame
    void Update()
    {
        MovementShileds();
    }

     void MovementShileds(){
        transform.position += Vector3.down * speed *Time.deltaTime;  

         if(transform.position.y <= -7.49f ){
            Destroy(gameObject);
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
