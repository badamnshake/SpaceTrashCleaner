using System.Collections;
using UnityEngine;

public class StopShooter : MonoBehaviour
{
    private Vector2 _origin, _destination;
    private Vector2 _wayPoint;
    private bool _moving;
    private bool _visitedDestination;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    [SerializeField] float hitDamage = 2f;
    [SerializeField] GameObject destroyEffect;

    public void SetPoints(Vector2 ori, Vector2 dest)
    {
        _origin = ori;
        _destination = dest;
        _moving = true;
    }


    private void FixedUpdate()
    {
        if (!_moving) return;
        Vector2 position = rb.position;
        _wayPoint = new Vector2(_destination.x - position.x, _destination.y - position.y);
        rb.MovePosition(position + _wayPoint.normalized * (speed * Time.fixedDeltaTime));
        if (_wayPoint.magnitude < 0.2)
        {
            if (_visitedDestination)
            {
                Die();
                return;
            }

            _destination = _origin;
            _moving = false;
            _visitedDestination = true;
            StartCoroutine(StopShootBehaviour());
        }
    }

    private IEnumerator StopShootBehaviour()
    {
        yield return new WaitForSeconds(2f);
        _moving = true;
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

            Die(true);
        }
    }

    private void Die(bool fireEffect = false)
    {
        if (fireEffect)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}