using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTypes", menuName = "CreateNewEnemy/Enemy", order = 0)]
public class SOEnemy : ScriptableObject
{
    public EnemyPath enemyPath;
    public GameObject projectilePrefab;
    public ShootPatternType shootPattern;
    public int noOfBulletsInOneAttack;
    public float timeBetweenAttacks;
    public bool isSmartEnemy = false; // yet to be implemented

}