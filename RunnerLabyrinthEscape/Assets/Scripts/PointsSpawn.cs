
using System.Collections;
using UnityEngine;

public class PointsSpawn : MonoBehaviour
{
    public GameObject points;
    public float spawnTime =2.0f; 
    public float xMin, xMax;

    void Start()
    {
        StartCoroutine(SpawnPoinstCoroutine());
    }
    
    IEnumerator SpawnPoinstCoroutine(){
        yield return new WaitForSeconds(spawnTime);
        Instantiate(points, transform.position + new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z), Quaternion.identity);
        StartCoroutine(SpawnPoinstCoroutine());

       
    }
}
