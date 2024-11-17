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
    public float spawnPoint = 2f;
    public float pointSpeed = 3f; // Kecepatan jatuh koin
    public float bombSpawnRate = 0f; // Frekuensi bom (0 artinya tidak muncul)
    public float shieldSpawnRate = 0f; // Frekuensi bom (0 artinya tidak muncul)
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
                spawnPoint = 2f;
                pointSpeed = 3f;
                bombSpawnRate = 0f;
                shieldSpawnRate = 0.2f;
                enablePowerUps = true;
                break;

            case 2: // Level menengah
                spawnPoint = 1.8f;
                pointSpeed = 5f;
                bombSpawnRate = 0.2f; // Bom muncul 20% dari waktu
                shieldSpawnRate = 0.2f; // Shield muncul 20% dari waktu
                enablePowerUps = false;
                break;

            case 3: // Level lanjut
                spawnPoint = 1.6f;
                pointSpeed = 7f;
                bombSpawnRate = 0.4f; // Bom muncul lebih sering
                shieldSpawnRate = 0.4f; // Shield muncul lebih sering
                enablePowerUps = true; // Power-up aktif
                break;

            default: // Level lebih tinggi
                spawnPoint += 0.1f;
                pointSpeed += 1f; // Tambahkan kecepatan jatuh
                bombSpawnRate += 0.1f; // Tambahkan frekuensi bom
                shieldSpawnRate += 0.1f; // Tambahkan frekuensi shield
                break;
        }
    }
}
