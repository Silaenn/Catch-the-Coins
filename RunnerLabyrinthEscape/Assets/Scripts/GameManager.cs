using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Level Settings")]
    public int currentLevel = 1; // Level awal
    public float levelDuration = 30f; // Durasi setiap level dalam detik
    private float levelTimer; // Timer untuk mengatur perubahan level

    [Header("Game Settings")]
    public float pointSpeed = 2f; // Kecepatan jatuh koin
    public float bombSpawnRate = 0f; // Frekuensi bom (0 artinya tidak muncul)
    public bool enablePowerUps = false; // Power-up aktif atau tidak

    void Start()
    {
        levelTimer = levelDuration; // Set timer sesuai durasi level
        UpdateLevelSettings(); // Atur pengaturan awal level
    }

    void Update()
    {
        // Kurangi timer setiap frame
        levelTimer -= Time.deltaTime;

        // Jika timer habis, naik ke level berikutnya
        if (levelTimer <= 0)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        currentLevel++; // Naikkan level
        levelTimer = levelDuration; // Reset timer
        UpdateLevelSettings(); // Perbarui pengaturan level
    }

    void UpdateLevelSettings()
    {
        // Atur pengaturan berdasarkan level
        switch (currentLevel)
        {
            case 1: // Level awal
                pointSpeed = 2f;
                bombSpawnRate = 0f;
                enablePowerUps = false;
                break;

            case 2: // Level menengah
                pointSpeed = 4f;
                bombSpawnRate = 0.2f; // Bom muncul 20% dari waktu
                enablePowerUps = false;
                break;

            case 3: // Level lanjut
                pointSpeed = 6f;
                bombSpawnRate = 0.4f; // Bom muncul lebih sering
                enablePowerUps = true; // Power-up aktif
                break;

            default: // Level lebih tinggi
                pointSpeed += 1f; // Tambahkan kecepatan jatuh
                bombSpawnRate += 0.1f; // Tambahkan frekuensi bom
                break;
        }

        Debug.Log($"Level {currentLevel} mulai: pointSpeed={pointSpeed}, BombRate={bombSpawnRate}, PowerUps={enablePowerUps}");
    }
}
