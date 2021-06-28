using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemies;
    private void Start()
    {
        Enemy enemy = Instantiate(enemies[0], enemies[0].GetEnemyOrigin(), Quaternion.identity);
    }


}
