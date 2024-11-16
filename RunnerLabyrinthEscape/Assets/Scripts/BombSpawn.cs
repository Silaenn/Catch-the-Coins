using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject bombPrefab;
    private float spawnRate;
    private int speed = 3;
    private int Poinst;

    void Update()
    {
        spawnRate = FindObjectOfType<GameManager>().bombSpawnRate;

        if(Random.value < spawnRate * Time.deltaTime){
            Instantiate(bombPrefab, new Vector3(Random.Range(-0.82f, 1.07f), 3.57f, 0), Quaternion.identity);
        }

        MovementBom();

    }

    void MovementBom(){
        transform.position += Vector3.down * speed *Time.deltaTime;  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Poinst = FindAnyObjectByType<PointScoring>().Points;
            
            if(Poinst <= 0){
                GameOver.instance.ShowGameOver();
            } else {
               Poinst -= 5;
            }
        }
    }
}
