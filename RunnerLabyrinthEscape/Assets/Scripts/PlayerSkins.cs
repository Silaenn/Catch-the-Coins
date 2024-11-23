using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkins : MonoBehaviour
{
    private SpriteRenderer playerRenderer;
    public Sprite defaultSprite;
    private const int DefaultSkinIndex = 0;

    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        LoadSkin();
    }

    void LoadSkin(){
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", DefaultSkinIndex);

        if (SkinManager.Instance != null && SkinManager.Instance.skins != null) {
            if (selectedSkinIndex >= 0 && selectedSkinIndex < SkinManager.Instance.skins.Length) {
                playerRenderer.sprite = SkinManager.Instance.skins[selectedSkinIndex];
            } else {
                playerRenderer.sprite = SkinManager.Instance.skins[DefaultSkinIndex];
                Debug.LogWarning("Invalid skin index, default skin applied.");
            }
        } else {
            if (defaultSprite != null) {
                playerRenderer.sprite = defaultSprite;
            } else {
                Debug.LogError("No default sprite assigned and SkinManager not available.");
            }
        }
    }
}
