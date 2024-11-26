using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ToInGame(){
        SceneManager.LoadScene("InGame");
        Debug.Log("masuk");
    }

    public void ToMainMenu(){
        SceneManager.LoadScene("InStart");
        Time.timeScale = 1;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
