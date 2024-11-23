using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNitro : MonoBehaviour
{
    AudioManager audioManager;
    private int speed = 3;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        MovementsNitro();
    }

    void MovementsNitro(){
        transform.position += Vector3.down * speed *Time.deltaTime;  
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
           PointScoring pointScoring = FindAnyObjectByType<PointScoring>();
            audioManager.PlaySFX(audioManager.Scoring); 
            pointScoring.AddPoints(5);
            Destroy(gameObject);
        }
    }
}
