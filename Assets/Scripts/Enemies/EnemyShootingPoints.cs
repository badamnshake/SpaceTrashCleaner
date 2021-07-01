using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingPoints : MonoBehaviour
{
    void Start()
    {
        if (IsEmpty())
        {
            Debug.Log("shooting points empty");
        }
    }
    public Transform GetShootPoint(int i)
    {
        return transform.GetChild(i);
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
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawCube(transform.GetChild(i).position, new Vector3(.1f, .1f, .1f));
        }
    }
}
