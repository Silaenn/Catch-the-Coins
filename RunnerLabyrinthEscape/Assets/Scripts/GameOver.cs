using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public int hiScore;
    string HISCORE = "HISCORE";
    public Text highTExtScore;

    private void Start() {
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

    private void Awake() {
        instance = this;
    }
    public GameObject gameOverPanel;

   public void ShowGameOver(){
    gameOverPanel.SetActive(true);
    PlayerLose();
    Time.timeScale = 0;
   }

   void PlayerLose(){
    PointScoring pointScoring = FindAnyObjectByType<PointScoring>();
    if(pointScoring.Points > hiScore){
        hiScore = pointScoring.Points;
        PlayerPrefs.SetInt(HISCORE, hiScore);
    }
    highTExtScore.text = "High Score: " +hiScore.ToString();
   }
}
