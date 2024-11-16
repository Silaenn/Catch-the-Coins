using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementBom : MonoBehaviour
{
    private int speed = 3;
    private int Poinst;   
    private Text TextPoint; 


    // Update is called once per frame
    void Update()
    {
        MovementBoms();
    }

     void MovementBoms(){
        transform.position += Vector3.down * speed *Time.deltaTime;  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
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
