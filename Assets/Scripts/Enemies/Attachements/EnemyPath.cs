using System;
using UnityEngine;


public class EnemyPath : MonoBehaviour
{
    private Camera _mainCam;
    private Vector2 _camPos;

    public bool isStopShooterPath = false;

    private int GetNextIndex(int i)
    {
        if (i + 1 == transform.childCount)
        {
            Gizmos.color = Color.gray;
            return 0;
        }

        return i + 1;
    }

    public Vector2 GetWayPoint(int i)
    {
        return CamOriginify(transform.GetChild(i).position);
    }

    public bool ExceedsIndex(int i)
        => i >= transform.childCount || i < 0;

    // enemy path is stored in a prefab its origin is 0,0 in game camera is always moving
    private Vector2 CamOriginify(Vector2 vector)
    {
        if (_mainCam is null)
        {
            _mainCam = Camera.main;
        }

        _camPos = _mainCam.transform.position;
        return new Vector2(vector.x + _camPos.x, vector.y + _camPos.y);
    }

    private void OnDrawGizmos()
    {
        Vector2[] points =
        {
            new Vector2(-7f, 4f),
            new Vector2(7f, 4f),
            new Vector2(7f, -4f),
            new Vector2(-7f, -4f)
        };
        // outline square of screen
        for (var i = 0; i < 4; i++)
        {
            var j = i + 1 < 4 ? i + 1 : 0;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(points[i], points[j]);
        }

        if (!isStopShooterPath)
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));
            }
        }
        else
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < transform.childCount; i += 2)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWayPoint(i), 0.2f);
                Gizmos.DrawSphere(GetWayPoint(j), 0.2f);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));
            }
        }
    }
}