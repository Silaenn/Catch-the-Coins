using System.Collections;
using UnityEngine;

public class MovementShield : MonoBehaviour
{
    private int speed = 3;
    private float immuneDuration = 1f;

    void Update()
    {
        MovementShileds();
    }

    void MovementShileds()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;  

        if(transform.position.y <= -7.49f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            MovementPlayer movementPlayer = other.GetComponent<MovementPlayer>();
            
            if (movementPlayer != null && !movementPlayer.isImmune) 
            {
                StartCoroutine(ImmunityTimer(movementPlayer));
            }
        }
    }

    private IEnumerator ImmunityTimer(MovementPlayer movementPlayer) 
    {
        movementPlayer.isImmune = true;
        
        yield return new WaitForSeconds(immuneDuration);
        
        movementPlayer.isImmune = false;
    }
}