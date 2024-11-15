using UnityEngine;
using UnityEngine.UI;

public class MovementPoints : MonoBehaviour
{
    private float speed;
    
    void Update()
    {
        speed = FindAnyObjectByType<GameManager>().pointSpeed;
        transform.position += Vector3.down * speed *Time.deltaTime;  

         if(transform.position.y <= -5.61f ){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            GameOver.instance.ShowGameOver();
        }
    }
}
