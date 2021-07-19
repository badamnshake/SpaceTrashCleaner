using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPath : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 camPos;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        camPos = mainCam.transform.position;
    }

    private void OnDrawGizmos()
    {
        Vector2[] points = {
            new Vector2(-7f, 4f),
            new Vector2(7f, 4f),
            new Vector2(7f, -4f),
            new Vector2(-7f, -4f)
        };
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextIndex(i);
            Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));
        }

        // outlne square of screen
        for (int i = 0; i < 4; i++)
        {
            int j = i + 1 < 4 ? i + 1 : 0;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(points[i], points[j]);
        }
    }
    public int GetNextIndex(int i)
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
    public bool IsEmpty()
    {
        if (transform.childCount == 0) return true;
        else return false;
    }
    public bool ExceedsIndex(int i)
    {
        if (i >= transform.childCount || i < 0)
            return true;
        else
            return false;
    }

    // enemy path is stored in a prefab its origin is 0,0 in game camera is always moving
    // so taking camera as 0,0 the origin is returned  
    public Vector2 CamOriginify(Vector2 vector)
    {
        return new Vector2(vector.x + camPos.x, vector.y + camPos.y);

    }

}
