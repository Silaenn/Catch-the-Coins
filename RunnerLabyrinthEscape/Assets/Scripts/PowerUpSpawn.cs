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
                Instantiate(powerUpPrefab, new Vector3(Random.Range(-1.58f, 1.43f), transform.position.y, 0), Quaternion.identity);
            }
        }    
    }
}
