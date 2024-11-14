using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPoints : MonoBehaviour
{
    private float speed = 3f;
    public GameObject gameOver;
    
    void Update()
    {
        transform.position += Vector3.down * speed *Time.deltaTime;  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(gameOver != null){
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
