using System.Collections;
using UnityEngine;

public class StopShooterSpawner : MonoBehaviour
{
    [SerializeField] private StopShooterPath[] stopShooterPaths;
    [SerializeField] private StopShooter[] stopShooterPrefabs;


    float _timeSinceLastWave = Mathf.Infinity;

    float _waitBeforeNextWave = 0.5f; // after one wave wait till
    float _waveInterval = 5f; // how long it takes to spawn one wave


    private void Update()
    {
        if (_timeSinceLastWave > _waveInterval + _waitBeforeNextWave)
        {
            // StartCoroutine(SpawnWave(GetRandomEnemy()));
            SpawnWave(GetRandomEnemy());
            _timeSinceLastWave = 0;
        }
        else
        {
            _timeSinceLastWave += Time.deltaTime;
        }
    }

    private void SpawnWave(StopShooter enemy)
    {
        StopShooterPath path = GetRandomPath();
        int enemiesInWave = path.GetSpawnPointCount();

        Vector2[] spawnPos = path.GetWayPointArray(false);
        Vector2[] desPos = path.GetWayPointArray(true);


        // float waitBeforeSpawningNext = _waveInterval / enemiesInWave;

        for (int i = 0; i < enemiesInWave; i++)
        {
            // spawning enemy and setting up vars
            GameObject shooter = Instantiate(enemy.gameObject, spawnPos[i], Quaternion.identity);
            shooter.GetComponent<StopShooter>().SetPoints(spawnPos[i], desPos[i]);

            // yield return new WaitForSeconds(waitBeforeSpawningNext);
        }
    }


    private StopShooter GetRandomEnemy() => stopShooterPrefabs[Random.Range(0, stopShooterPrefabs.Length)];
    private StopShooterPath GetRandomPath() => stopShooterPaths[Random.Range(0, stopShooterPaths.Length)];
}