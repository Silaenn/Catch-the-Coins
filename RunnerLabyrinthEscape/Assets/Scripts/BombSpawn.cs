using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject bombPrefab;
    private float spawnRate;

    void Update()
    {
        spawnRate = FindObjectOfType<GameManager>().bombSpawnRate;

        if(Random.value < spawnRate * Time.deltaTime){
            Instantiate(bombPrefab, new Vector3(Random.Range(-1.58f, 1.43f), transform.position.y, 0), Quaternion.identity);
        }
    }

   
}
