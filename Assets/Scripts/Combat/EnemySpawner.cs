using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] easyEnemies, mediumEnemies, hardEnemies, expertEnemies;

    float timeSinceLastWave = Mathf.Infinity;
    float waitBeforeNextWave = 0.5f;

    int _easyWaveProbability,
        _mediumWaveProbability,
        _hardWaveProbability,
        _expertProbability; // chance of spawning an easy enemy wave

    int _easyEnPerWave = 7;
    int _mediumEnPerWave = 5;
    int _hardEnPerWave = 3;
    int _expertEnPerWave = 2;

    int wavesCount = 1; // enemies waves spawned per Interval
    float waveInterval = 2f; // wait before spawning new wave
    float enemySpeedIncFraction;


    // Increment Intervlas
    float perWaveEnemyCount_II = 12f;
    float enemyDifficulty_II = 7f;
    float enemySpeed_II = 9f;

    private void Start()
    {
        StartCoroutine(IncreaseEnemyChance());
        StartCoroutine(IncreaseEnemiesPerWave());
        StartCoroutine(IncreaseEnemySpeeds());

        // take enemy array and divide
    }

    private void Update()
    {
        if (timeSinceLastWave > waveInterval + waitBeforeNextWave)
        {
            //could go with random range to make things interesting
            CheckProbabilitiesSpawnWaves();
            timeSinceLastWave = 0;
        }
        else
        {
            timeSinceLastWave += Time.deltaTime;
        }
    }

    private void CheckProbabilitiesSpawnWaves()
    {
        if (GetChance(_expertProbability))
        {
            StartCoroutine(SpawnWave(GetRandomEnemy(expertEnemies), enemySpeedIncFraction, _expertEnPerWave));
        }
        else if (GetChance(_hardWaveProbability))
        {
            StartCoroutine(SpawnWave(GetRandomEnemy(hardEnemies), enemySpeedIncFraction, _hardEnPerWave));
        }
        else if (GetChance(_mediumWaveProbability))
        {
            StartCoroutine(SpawnWave(GetRandomEnemy(mediumEnemies), enemySpeedIncFraction, _mediumEnPerWave));
        }
        else
        {
            StartCoroutine(SpawnWave(GetRandomEnemy(easyEnemies), enemySpeedIncFraction, _easyEnPerWave));
        }
    }

    private IEnumerator SpawnWave(Enemy enemy, float enemySpeedIncFraction, int enPerWave)
    {
        float waitBeforeSpawningNext = (1f - enemySpeedIncFraction) / 10f;
        for (int i = 0; i < _easyEnPerWave; i++)
        {
            SpawnEnemy(enemy, enemySpeedIncFraction);
            yield return new WaitForSeconds(waitBeforeSpawningNext);
        }
    }

    private void SpawnEnemy(Enemy enemy, float enemySpeedIncFraction)
    {
        // gotta implement
        GameObject gO = Instantiate(enemy.gameObject, enemy.GetEnemyOrigin(), Quaternion.identity);
    }

    private Enemy GetRandomEnemy(Enemy[] enemies)
    {
        int randomIndex = Random.Range(0, enemies.Length);
        return enemies[randomIndex];
    }

    private bool GetChance(int probability)
    {
        float fraction = probability / 100f;
        return Random.Range(0f, 1f) < fraction;
    }


    IEnumerator IncreaseEnemySpeeds()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpeed_II);
            enemySpeedIncFraction += enemySpeedIncFraction * 0.1f;
        }
    }

    IEnumerator IncreaseEnemiesPerWave()
    {
        bool onHighestDifficulty = false;
        while (!onHighestDifficulty)
        {
            yield return new WaitForSeconds(perWaveEnemyCount_II);
            _easyEnPerWave++;
            _mediumEnPerWave++;
            _hardEnPerWave++;
            _expertEnPerWave++;
            if (_easyEnPerWave >= 10)
            {
                onHighestDifficulty = true;
            }
        }
    }

    IEnumerator IncreaseEnemyChance()
    {
        short diffCounter = -1;
        bool notOnHighestDifficulty = true;
        while (notOnHighestDifficulty)
        {
            yield return new WaitForSeconds(enemyDifficulty_II);
            
            diffCounter++;
            switch (diffCounter)
            {
                case 0:
                    ChangeSpawnChances(100, 25, 0, 0);
                    break;
                case 1:
                    ChangeSpawnChances(25, 100, 25, 0);
                    break;
                case 3:
                    ChangeSpawnChances(10, 100, 75, 10);
                    break;
                case 5:
                    ChangeSpawnChances(10, 25, 100, 20);
                    break;
                case 7:
                    ChangeSpawnChances(10, 25, 75, 50);
                    break;
                case 9:
                    ChangeSpawnChances(10, 10, 90, 90);
                    break;
                case 10:
                    notOnHighestDifficulty = false;
                    break;
            }
        }
    }

    private void ChangeSpawnChances(int easy, int med, int hard, int exp)
    {
        _easyWaveProbability = easy;
        _mediumWaveProbability = med;
        _hardWaveProbability = hard;
        _expertProbability = exp;
    }
}