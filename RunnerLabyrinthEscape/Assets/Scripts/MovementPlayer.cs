using System.Collections;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 3;
    public float minX = -5f; // Batas kiri
public float maxX = 5f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        HandleTouch();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bom")){
            HandleKnockbackAndImmunity();
        }
    }

    IEnumerator HandleKnockbackAndImmunity(){
        for (int i = 0; i < 6; i++)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.25f);
        }
    }

    void HandleTouch()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x > Screen.width / 2) 
                {
                    MoveRight();
                }
                else if (touch.position.x <= Screen.width / 2) 
                {
                    MoveLeft();
                }
            }
    }
}


     void MoveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z
        );
    }

    void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z
        );
    }
}
