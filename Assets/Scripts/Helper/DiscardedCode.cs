// void SetBulletPoints(PatternInfo patternInfo)
// {
//     Vector2 myPos = rb.position;
//      currentParent = Instantiate(OneBulletWaveParent, rb.position, Quaternion.identity);
//     if (bulletSpawnPositions.Count == 0)
//     {
//         for (int i = 0; i < patternInfo.Length(); i++)
//         {
//             bulletSpawnPositions.Add(new Vector2(patternInfo.posArr[i].x + myPos.x, patternInfo.posArr[i].y + myPos.y));
//             // bulletSpawnPositions.Add(new Vector2(myPos.x, myPos.y));
//         }
//     }
//     else
//     {
//         for (int i = 0; i < patternInfo.Length(); i++)
//         {
//             bulletSpawnPositions[i] = new Vector2(patternInfo.posArr[i].x + myPos.x, patternInfo.posArr[i].y + myPos.y);
//             // bulletSpawnPositions[i] = new Vector2(myPos.x, myPos.y);
//         }
//     }
// }
// private void GetPatternInfo()
// {
//     switch (shootPattern)
//     {
//         case ShootPatternType.Arc:
//             patternInfo = SpawnPatterns.ArcSpread(bulletsInOneAttack, distanceFromSpawner: 0.01f);
//             havePatternInfo = true;
//             break;
//         case ShootPatternType.Linear:
//             patternInfo = SpawnPatterns.LineSpread(bulletsInOneAttack, distanceBetBullets);
//             havePatternInfo = true;
//             break;
//         default:
//             break;
//     }
// }
// Vector2 dir = rb.position - new Vector2(bulletSpawnPositions[i].x, bulletSpawnPositions[i].y);
// float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
// public enum ShootPatternType {
//     Arc,
//     Linear
// }
// public struct PatternInfo
// {
//     public List<Vector2> posArr;
//     // consturctor
//     public PatternInfo(List<Vector2> positions )
//     {
//         this.posArr = positions;
//     }
//     public int Length() {
//        return posArr.Count; 
//     }
// }
// public class SpawnPatterns : MonoBehaviour
// {


//     public static PatternInfo ArcSpread(int numberOfPoints, float offsetAngle = 0f, float arcDegrees = 360f, float distanceFromSpawner = 1)
//     {
//         List<Vector2> posArr = new List<Vector2>();

//         float fraction = arcDegrees / numberOfPoints;
//         float currentAngle = offsetAngle;

//         if (numberOfPoints < 2)
//         {
//             Debug.Log(numberOfPoints);
//             Debug.LogError("Passing number of points < 2 in ArcSpread");
//             return new PatternInfo(posArr);
//         }

//         posArr.Add(PointsFromAngle(currentAngle, distanceFromSpawner));

//         for (int i = 0; i < numberOfPoints - 1; i++) // first point is offset so x-1 remain
//         {
//             currentAngle = currentAngle + fraction;
//             posArr.Add(PointsFromAngle(currentAngle, distanceFromSpawner));
//         }

//         return new PatternInfo(posArr);
//     }
//     public static PatternInfo LineSpread(int numberOfPoints, float distanceBetPoints, float offset = 0, float distanceFromSpawner = 1)
//     {
//         List<Vector2> posArr = new List<Vector2>();

//         float startingPoint = offset;

//         if (numberOfPoints < 2)
//         {
//             Debug.LogError("Passing number of points < 2 in linespread");
//             return new PatternInfo(posArr);
//         }
//         if (isEven(numberOfPoints))
//         {
//             startingPoint -= (numberOfPoints + 1) * distanceBetPoints * 0.5f;
//         }
//         else
//         {
//             startingPoint -= (numberOfPoints - 1) * distanceBetPoints * 0.5f;
//         }


//         posArr.Add(new Vector2(startingPoint, distanceFromSpawner));

//         for (int i = 0; i < numberOfPoints - 1; i++)
//         {

//             startingPoint += distanceBetPoints;
//             posArr.Add(new Vector2(startingPoint, distanceFromSpawner));

//         }

//         return new PatternInfo(posArr);
//     }


//     public static Vector2 PointsFromAngle(float angleZ, float distanceFromSpawner = 1)
//     {
//         return new Vector2(Mathf.Cos(angleZ), Mathf.Sin(angleZ)) * distanceFromSpawner;
//     }
//     public static bool isEven(int number) => number % 2 == 0 ? true : false;
// }
