using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementBom : MonoBehaviour
{
    private int speed = 3;
    AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        MovementBoms();
    }

     void MovementBoms(){
        transform.position += Vector3.down * speed *Time.deltaTime;  

         if(transform.position.y <= -7.49f ){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        MovementPlayer movementPlayer = FindAnyObjectByType<MovementPlayer>();
        if(other.CompareTag("Player") && !movementPlayer.isImmune){
           audioManager.PlaySFX(audioManager.Boom);
           PointScoring pointScoring = FindAnyObjectByType<PointScoring>();
            
            if(pointScoring.Points <= 0){
                GameOver.instance.ShowGameOver();
            } else {
              pointScoring.SubtractPoints(5);
            }

            Destroy(gameObject);
        }
    }
}
