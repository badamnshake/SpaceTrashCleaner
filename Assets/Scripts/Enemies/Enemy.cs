using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SOEnemy enemyData;
    public Rigidbody2D rb;
    public float speed = 2f;
    public bool loopPath = false;
    public bool canShoot = true;

    int currWayPointIndex = 0;
    EnemyPath path;
    GameObject enemy;
    Vector2 wayPoint;
    bool isShooting = false;
    float shootingTimeout = 0.25f;
    float timeSinceLastShoot = Mathf.Infinity;

    private void Awake()
    {
        path = enemyData.enemyPath;
        if (canShoot)
        {
            GetComponent<EnemyShoot>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (canShoot && timeSinceLastShoot < shootingTimeout) return;
        MoveAlongPath(loopPath);
    }

    private void Update()
    {
        timeSinceLastShoot += Time.deltaTime;
    }

    private void MoveAlongPath(bool loopPath)
    {
        if (path.ExceedsIndex(currWayPointIndex))
        {
            if (!loopPath)
                Die();
            else
                currWayPointIndex = 0;
        }

        wayPoint = path.GetWayPoint(currWayPointIndex);

        var position = rb.position;

        wayPoint = new Vector2(wayPoint.x - position.x, wayPoint.y - position.y);
        if (wayPoint.magnitude < 0.2)
        {
            currWayPointIndex++;
        }

        rb.MovePosition(position + wayPoint.normalized * (speed * Time.fixedDeltaTime));
    }

    public Vector2 GetEnemyOrigin()
    {
        path = enemyData.enemyPath;
        return path.GetWayPoint(currWayPointIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OutBound"))
        {
            Die();
        }
    }

    private void Die()
    {
        print("Enemy hit the wall");
        // Destroy(gameObject);
    }

    public void SetIsShooting(bool shootin)
    {
        if (shootin) timeSinceLastShoot = 0f;
        isShooting = shootin;
    }
}