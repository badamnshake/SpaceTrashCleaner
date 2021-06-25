using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    void Update()
    {
        Movement();
        Aim();
    }
    void Movement()
    {
        Vector2 toMoveDir = new Vector2(0, 0);

        if (Input.GetKey(KeyMap.Up)) toMoveDir.y = 1;
        else if (Input.GetKey(KeyMap.Down)) toMoveDir.y = -1;

        if (Input.GetKey(KeyMap.Right)) toMoveDir.x = 1;
        else if (Input.GetKey(KeyMap.Left)) toMoveDir.x = -1;

        if (toMoveDir.magnitude > 1)
        {
            toMoveDir = toMoveDir * 0.7071f;
        }
        rb.MovePosition(rb.position + toMoveDir * moveSpeed * Time.fixedDeltaTime);
    }
    void Aim()
    {
        Vector2 aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
