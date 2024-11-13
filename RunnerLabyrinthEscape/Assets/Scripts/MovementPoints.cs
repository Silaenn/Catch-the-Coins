using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPoints : MonoBehaviour
{
    private float speed = 3f;
    
    void Update()
    {
        transform.position += Vector3.down * speed *Time.deltaTime;  
    }
}
