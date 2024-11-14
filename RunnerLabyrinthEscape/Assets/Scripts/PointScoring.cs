using UnityEngine;
using UnityEngine.UI;

public class PointScoring : MonoBehaviour
{
    public Text TextPoint; 
    private int Points = 0;
   
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Points")){
        Points++;
        TextPoint.text = Points.ToString();
    }
   }
}
