using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject powerUpPrefab;
    
    void Update()
    {
        if(FindObjectOfType<GameManager>().enablePowerUps){
            if(Random.value < 0.05f * Time.deltaTime){
                Instantiate(powerUpPrefab, new Vector3(Random.Range(-5f, 5f), 10f, 0), Quaternion.identity);
            }
        }    
    }
}
