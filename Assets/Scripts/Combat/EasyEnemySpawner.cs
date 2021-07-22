using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class EasyEnemySpawner : MonoBehaviour
{
    [NotNull] [SerializeField] EasyEnemy[] enemyPrefabs;

    float _timeSinceLastWave = Mathf.Infinity;
    private int _enemiesPerWave = 4;

    float _waitBeforeNextWave = 0.5f; // after one wave wait till
    float _waveInterval = 2f; // how long it takes to spawn one wave
    float _perWaveEnemyCountIi = 12f; // II stands for increment interval

    private void Start()
    {
        StartCoroutine(IncreaseEnemiesPerWave());
    }

    private void Update()
    {
        if (_timeSinceLastWave > _waveInterval + _waitBeforeNextWave)
        {
            StartCoroutine(SpawnWave(GetRandomEnemy(enemyPrefabs)));
            _timeSinceLastWave = 0;
        }
        else
        {
            _timeSinceLastWave += Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(EasyEnemy enemy)
    {
        float waitBeforeSpawningNext = _waveInterval / _enemiesPerWave;
        for (int i = 0; i < _enemiesPerWave; i++)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(waitBeforeSpawningNext);
        }
    }

    private void SpawnEnemy(EasyEnemy enemy)
    {
        Instantiate(enemy.gameObject, enemy.GetEnemyOrigin(), Quaternion.identity);
    }

    private EasyEnemy GetRandomEnemy(EasyEnemy[] enemies) => enemies[Random.Range(0, enemies.Length)];

    IEnumerator IncreaseEnemiesPerWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(_perWaveEnemyCountIi);
            _enemiesPerWave++;
            if (_enemiesPerWave >= 9)
            {
                break;
            }
        }
    }
}