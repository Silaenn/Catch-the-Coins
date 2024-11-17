using System.Collections;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 3;
    public float minX = -5f; // Batas kiri
    public float maxX = 5f; 
    public bool isImmune = false; // Status imun
    public float immuneDuration = 1.5f; // Durasi imun


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
        if(other.CompareTag("Bom") && !isImmune){
            StartCoroutine(HandleKnockbackAndImmunity());
        }
    }

   IEnumerator HandleKnockbackAndImmunity()
{
    isImmune = true;
    SpriteRenderer sr = GetComponent<SpriteRenderer>();
    Color originalColor = sr.color;

    float elapsed = 0f;
    while (elapsed < immuneDuration)
    {
        sr.enabled = !sr.enabled;
        sr.color = sr.enabled ? Color.red : originalColor; 
        yield return new WaitForSeconds(0.2f);
        elapsed += 0.2f;
    }

    sr.color = originalColor;
    sr.enabled = true;
    isImmune = false;
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
