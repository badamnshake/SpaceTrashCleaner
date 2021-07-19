using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;
    public bool loopPath = false;
    public EnemyPath path;

    int _currWayPointIndex = 0;
    GameObject _destroyEffect;
    Vector2 _wayPoint;

    private void Update()
    {
        MoveAlongPath();
    }


    private void MoveAlongPath()
    {
        if (path.ExceedsIndex(_currWayPointIndex))
        {
            if (!loopPath)
                Die();
            else
                _currWayPointIndex = 0;
        }

        _wayPoint = path.GetWayPoint(_currWayPointIndex);

        var position = rb.position;

        _wayPoint = new Vector2(_wayPoint.x - position.x, _wayPoint.y - position.y);
        if (_wayPoint.magnitude < 0.2)
        {
            _currWayPointIndex++;
        }

        rb.MovePosition(position + _wayPoint.normalized * (speed * Time.fixedDeltaTime));
    }

    public Vector2 GetEnemyOrigin()
    {
        return path.GetWayPoint(_currWayPointIndex);
    }

    private void Die()
    {
        print("Enemy hit the wall");
        // Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tag: "OutBound"))
        {
            Die();
        }
        else if (other.CompareTag(tag: "PlayerBullet"))
        {
            
        }
    }
}