using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SOEnemy enemyData;
    public Rigidbody2D rb;
    public float speed = 2f;
    public bool loopPath = false;

    int currWayPointIndex = 0;
    EnemyPath path;
    GameObject enemy;
    Vector2 wayPoint;

    private void Awake()
    {
        path = enemyData.enemyPath;
    }
    private void FixedUpdate()
    {
        MoveAlongPath(loopPath);
        ShootBehaviour();
    }
    private void ShootBehaviour() {
        
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
        wayPoint = new Vector2(wayPoint.x - rb.position.x, wayPoint.y - rb.position.y);
        if (wayPoint.magnitude < 0.2)
        {
            currWayPointIndex++;
        }
        rb.MovePosition(rb.position + wayPoint.normalized * speed * Time.fixedDeltaTime);
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
        Destroy(gameObject);
    }
}
