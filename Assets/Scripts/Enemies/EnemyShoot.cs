using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public SOEnemy enemyData;

    ShootPatternType shootPattern;
    int bulletsInOneAttack;
    float distanceBetBullets;
    float timeBetweenAttacks;
    float bulletSpeed;
    GameObject projectile;


    List<Vector2> bulletSpawnPositions = new List<Vector2>() { };
    List<Quaternion> bulletSpawnRotations = new List<Quaternion>() { };
    float timeSinceLastAttack = Mathf.Infinity;

    void Awake()
    {
        shootPattern = enemyData.shootPattern;
        bulletsInOneAttack = enemyData.noOfBulletsInOneAttack;
        bulletSpeed = enemyData.noOfBulletsInOneAttack;
        timeBetweenAttacks = enemyData.timeBetweenAttacks;
        projectile = enemyData.projectilePrefab;
        distanceBetBullets = enemyData.distanceBetBullets;
    }

    void Update()
    {
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {

            switch (shootPattern)
            {
                case ShootPatternType.Arc:
                    SetBulletPoints(SpawnPatterns.ArcSpread(bulletsInOneAttack));
                    break;
                case ShootPatternType.Linear:
                    SetBulletPoints(SpawnPatterns.LineSpread(bulletsInOneAttack, distanceBetBullets));
                    break;
                default:
                    break;
            }

            SpawnBullets();

            timeSinceLastAttack = 0;
        }

        // update timers
        timeSinceLastAttack += Time.deltaTime;

    }

    void SpawnBullets()
    {
        for (int i = 0; i < bulletsInOneAttack; i++)
        {
            GameObject bullet = Instantiate(projectile, bulletSpawnPositions[i], bulletSpawnRotations[i]);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        }
    }


    void SetBulletPoints(PatternInfo patternInfo)
    {
        for (int i = 0; i < patternInfo.Length(); i++)
        {
            Vector2 myPos = transform.position;
            bulletSpawnPositions.Add(new Vector2(patternInfo.posArr[i].x + myPos.x, patternInfo.posArr[i].y + myPos.y));

            Quaternion currentRotation = new Quaternion();
            currentRotation.eulerAngles = new Vector3(0, 0, patternInfo.zRotationArr[i]);
            bulletSpawnRotations.Add(currentRotation);

        }
    }
}
