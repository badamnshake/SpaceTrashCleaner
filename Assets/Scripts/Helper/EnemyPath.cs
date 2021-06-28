using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextIndex(i);
            Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));
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
        Vector2 camPosition = Camera.main.transform.position;
        return new Vector2(vector.x + camPosition.x, vector.y + camPosition.y);

    }
}
