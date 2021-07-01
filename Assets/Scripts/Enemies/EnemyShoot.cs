using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public SOEnemy enemyData;
    public Rigidbody2D rb;
    public Enemy enemy;
    public Transform[] bulletPoints;
    public EnemyShootingPoints shootingPoints;

    float timeBetweenAttacks;
    float bulletSpeed;
    GameObject projectile;


    public float timeSinceLastAttack = 0;

    GameObject OneBulletWaveParent;
    GameObject currentParent;

    void Start()
    {
        timeBetweenAttacks = enemyData.timeBetweenAttacks;
        projectile = enemyData.projectilePrefab;
        bulletSpeed = enemyData.bulletSpeed;
    }

    void Update()
    {
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            SpawnBullets();
            timeSinceLastAttack = 0;
        }
        timeSinceLastAttack += Time.deltaTime;
    }


    void SpawnBullets()
    {

        enemy.SetIsShooting(true);
        for (int i = 0; !shootingPoints.ExceedsIndex(i) ; i++)
        {
          GameObject bullet =  Instantiate(projectile, shootingPoints.GetShootPoint(i).position, shootingPoints.GetShootPoint(i).rotation);
          bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        }
        enemy.SetIsShooting(false);
    }

}
