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
            Instantiate(bombPrefab, new Vector3(Random.Range(-0.82f, 1.07f), 3.57f, 0), Quaternion.identity);
        }
    }
}
