using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatterns : MonoBehaviour
{

    private void Start()
    {
        ArcSpread(10);
    }

    public static PatternInfo ArcSpread(int numberOfPoints, float offsetAngle = -90f, float arcDegrees = 360f, float distanceFromSpawner = 1)
    {
        List<Vector2> posArr = new List<Vector2>();
        List<float> zRotationArr = new List<float>();

        float fraction = arcDegrees / numberOfPoints;
        float currentAngle = offsetAngle;

        if (numberOfPoints < 2)
        {
            Debug.LogError("Passing number of points < 2 in ArcSpread");
            return new PatternInfo(posArr, zRotationArr);
        }

        zRotationArr.Add(currentAngle * Mathf.Deg2Rad);
        posArr.Add(PointsFromAngle(currentAngle, distanceFromSpawner));

        for (int i = 0; i < numberOfPoints - 1; i++) // first point is offset so x-1 remain
        {
            currentAngle = currentAngle + fraction;
            zRotationArr.Add(currentAngle * Mathf.Deg2Rad);
            posArr.Add(PointsFromAngle(currentAngle, distanceFromSpawner));
        }

        return new PatternInfo(posArr, zRotationArr);
    }
    public static PatternInfo LineSpread(int numberOfPoints, float distanceBetPoints, float offset = 0, float distanceFromSpawner = 1)
    {
        List<Vector2> posArr = new List<Vector2>();
        List<float> zRotationArr = new List<float>();

        float startingPoint = offset;

        if (numberOfPoints < 2)
        {
            Debug.LogError("Passing number of points < 2 in linespread");
            return new PatternInfo(posArr, zRotationArr);
        }
        if (isEven(numberOfPoints))
        {
            startingPoint -= (numberOfPoints + 1) * distanceBetPoints * 0.5f;
        }
        else
        {
            startingPoint -= (numberOfPoints - 1) * distanceBetPoints * 0.5f;
        }


        zRotationArr.Add(0);
        posArr.Add(new Vector2(startingPoint, distanceFromSpawner));

        for (int i = 0; i < numberOfPoints - 1; i++)
        {
            zRotationArr.Add(0);

            startingPoint += distanceBetPoints;
            posArr.Add(new Vector2(startingPoint, distanceFromSpawner));

        }

        return new PatternInfo(posArr, zRotationArr);
    }


    public static Vector2 PointsFromAngle(float angleZ, float distanceFromSpawner = 1)
    {
        return new Vector2(Mathf.Cos(angleZ), Mathf.Sin(angleZ)) * distanceFromSpawner;
    }
    public static bool isEven(int number) => number % 2 == 0 ? true : false;
}
