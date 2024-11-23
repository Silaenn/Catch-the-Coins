using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinObject : MonoBehaviour
{
   public int skinIndex;
    public SkinManager skinManager;

  private void OnMouseDown() {
    skinManager.ChangeSkin(skinIndex);
    SceneManager.LoadScene("InGame");
}

}
