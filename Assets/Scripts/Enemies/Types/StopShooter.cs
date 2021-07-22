using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopShooter : MonoBehaviour
{
    private Vector2 origin;
    private Vector2 destination;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    [SerializeField] float hitDamage = 2f;
    [SerializeField] bool loopPath;
    [SerializeField] EnemyPath path;
    [SerializeField] GameObject _destroyEffect;

    public void SetPoints(Vector2 ori, Vector2 dest)
    {
        origin = ori;
        destination = dest;
    }


    int _currWayPointIndex;
    Vector2 _wayPoint;

    private void FixedUpdate()
    {
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        if (path.ExceedsIndex(_currWayPointIndex))
        {
            if (!loopPath)
            {
                Die();
                return;
            }

            _currWayPointIndex = 0;
        }

        _wayPoint = path.GetWayPoint(_currWayPointIndex);

        var position = rb.position;

        _wayPoint = new Vector2(_wayPoint.x - position.x, _wayPoint.y - position.y);

        if (_wayPoint.magnitude < 0.2)
            _currWayPointIndex++;

        rb.MovePosition(position + _wayPoint.normalized * (speed * Time.fixedDeltaTime));
    }

    public Vector2 GetEnemyOrigin()
    {
        return path.GetWayPoint(_currWayPointIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // TODO: add health script
            Die(true);
        }
        else if (other.CompareTag("Player"))
        {
            print("hit player");

            GameObject.FindWithTag("Player").GetComponent<IHealth>().TakeDamage(hitDamage);

            // other.GetComponentInParent<GameObject>().GetComponentInParent<GameObject>().GetComponentInParent<IHealth>()
            // .TakeDamage(hitDamage);
            Die(true);
        }
    }

    private void Die(bool fireEffect = false)
    {
        if (fireEffect)
        {
            Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}