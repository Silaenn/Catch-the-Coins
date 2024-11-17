using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNitro : MonoBehaviour
{
    private int speed = 3;

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
            pointScoring.AddPoints(5);
            Destroy(gameObject);
        }
    }
}
