using System;
using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;

    public Transform SpawnPoint;

    public UnityEngine.UI.Text waveCountdownText;
    public UnityEngine.UI.Text waveText;

    public float timeBetweenWaves = 5f;

    public float enemyReset = 0.4f;

    private float countdown = 2f;
    private int waveNumber = 0;
    private bool spawning = false;

    void Update()
    {
        if (countdown <= 0f && !spawning)
        {
            spawning = true;
            StartCoroutine(SpawnWave());
        }
        countdown -= Time.deltaTime;

        if (countdown > 0f)
            waveCountdownText.text = "Next wave in: " + (Math.Round(countdown, 1)).ToString("0.0");
        else waveCountdownText.text = "Spawn in process";
    }

    IEnumerator SpawnWave()
    {
        waveText.text = "Wave: " + (++waveNumber).ToString();
        PlayerStats.Rounds++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemyReset);
        }

        countdown = timeBetweenWaves;
        spawning = false;
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
