using System;
using UnityEngine;
using UnityEngine.UI;

public class PointScoring : MonoBehaviour
{
    public Text TextPoint; 
    public int Points = 0;

    AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        UpdateUI();
    }

    public void AddPoints(int amount){
        Points += amount;
        UpdateUI();
    }

    public void SubtractPoints(int amount){
        Points -= amount;
        Points = Mathf.Max(0, Points);
        UpdateUI();
    }

    private void UpdateUI()
    {
        TextPoint.text = Points.ToString(); 
    }
   
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Points")){
        audioManager.PlaySFX(audioManager.Scoring);
        AddPoints(1);
    }
   }
}
