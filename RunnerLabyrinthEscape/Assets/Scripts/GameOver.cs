using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public int hiScore;
    string HISCORE = "HISCORE";
    public Text scoreText, highTextScore;
    public AudioSource backgroundMusic;
    AudioManager audioManager;

    private void Start() {
        hiScore = PlayerPrefs.GetInt(HISCORE);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Awake() {
        instance = this;
    }
    public GameObject gameOverPanel;

   public void ShowGameOver(){
    gameOverPanel.SetActive(true);
    PlayerLose();
    Time.timeScale = 0;

    if(backgroundMusic != null){
        backgroundMusic.Stop();
    }
    audioManager.Over(audioManager.Overs);
   }

   void PlayerLose(){
    PointScoring pointScoring = FindAnyObjectByType<PointScoring>();
    if(pointScoring.Points > hiScore){
        hiScore = pointScoring.Points;
        PlayerPrefs.SetInt(HISCORE, hiScore);
    }
    highTextScore.text = "High Score: " +hiScore.ToString();
    scoreText.text = "CurrentScore: " + pointScoring.Points.ToString();
   }
}
