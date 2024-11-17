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
    public float targetOpacity = 120f;

    private float originalOpacity;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null){
            originalOpacity = spriteRenderer.color.a;
        }
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

        if(other.CompareTag("Shield") && !isImmune){
            StartCoroutine(GrantImmunity());
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

IEnumerator GrantImmunity()
    {
        isImmune = true;
        SetOpacity(targetOpacity);
        yield return new WaitForSeconds(4f); 
        isImmune = false;
        ResetOpacity();
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

    void SetOpacity(float opacity){
        float nomalizedOpacity = Mathf.Clamp(opacity / 255f, 0f, 1f);
        if(spriteRenderer != null){
            Color color = spriteRenderer.color;
            color.a = nomalizedOpacity;
            spriteRenderer.color = color;
        }
    }

     private void ResetOpacity()
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = originalOpacity; // Kembalikan ke alpha awal
            spriteRenderer.color = color;
        }
    }
}
