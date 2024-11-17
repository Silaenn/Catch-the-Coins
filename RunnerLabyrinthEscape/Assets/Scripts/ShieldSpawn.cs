using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
     public GameObject shieldPrefab;
    private float spawnRate;

    void Update()
    {
        spawnRate = FindObjectOfType<GameManager>().shieldSpawnRate;

        if(Random.value < spawnRate * Time.deltaTime){
            Instantiate(shieldPrefab, new Vector3(Random.Range(-1.58f, 1.43f), transform.position.y, 0), Quaternion.identity);
        }
    }
}
