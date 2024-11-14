using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    private void Awake() {
        instance = this;
    }
    public GameObject gameOverPanel;

   public void ShowGameOver(){
    gameOverPanel.SetActive(true);
    Time.timeScale = 0;
   }
}
