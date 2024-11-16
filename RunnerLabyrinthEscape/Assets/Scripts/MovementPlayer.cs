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
        // Hanya menggunakan satu input untuk gerakan
        float moveInput = Input.GetAxis("Horizontal");
        
        // Gerakkan pemain dengan velocity (fisika)
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

    // Menangani input sentuhan
    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x > Screen.width / 2 && rb.velocity.x != speed)
                {
                MoveRight();
                }
            else if (touch.position.x <= Screen.width / 2 && rb.velocity.x != -speed)
                {
                MoveLeft();
                }
            }
        }
    }

    void MoveRight()
    {
        if (transform.position.x < maxX) // Pastikan pemain tidak melebihi batas kanan
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    void MoveLeft()
    {
        if (transform.position.x > minX) // Pastikan pemain tidak melewati batas kiri
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
}
