using UnityEngine;


public class StopShooterPath : MonoBehaviour
{
    public Vector2[] GetWayPointArray(bool isDestination)
    {
        Vector2[] result = new Vector2[transform.childCount / 2];
        int x = 0;
        int i = isDestination ? 1 : 0;

        while (i < transform.childCount)
        {
            result[x] = transform.GetChild(i).position;
            x++;
            i += 2;
        }

        return result;
    }

    public int GetSpawnPointCount() => transform.childCount / 2;

    private int GetNextIndex(int i) => i + 1 == transform.childCount ? 0 : i + 1;

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

        if (transform.childCount % 2 != 0)
        {
            return;
        }

        for (int i = 0; i < transform.childCount; i += 2)
        {
            int j = GetNextIndex(i);
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.GetChild(i).position, 0.2f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.GetChild(j).position, 0.2f);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(j).position);
        }
    }
}