using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
            if (clickedObject != null)
            {
                Debug.Log("Clicked on: " + clickedObject.name);
            }
            else
            {
                Debug.Log("No object clicked.");
            }
        }
    }
}
