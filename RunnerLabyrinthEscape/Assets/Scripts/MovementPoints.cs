using UnityEngine;
using UnityEngine.UI;

public class MovementPoints : MonoBehaviour
{
    private float speed;
    [SerializeField] private Sprite[] skins;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.rotation = Quaternion.Euler(180, 0, 0);
        ApplyRandomSkin();
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
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

    void ApplyRandomSkin(){
        if(skins.Length > 0){
            int randomIndex = Random.Range(0, skins.Length);
            spriteRenderer.sprite = skins[randomIndex];
        }
    }
}
