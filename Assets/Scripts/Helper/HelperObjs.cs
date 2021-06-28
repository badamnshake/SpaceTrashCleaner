using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipColor
{
    Yellow = 0,
    Green = 1,
    Black = 2,
    Purple = 3
}
public enum ShipSize
{
    Null = -1,
    Small = 0,
    Medium = 1,
    Large = 2,
}
[Serializable]
public struct ShipData
{
    public ShipColor shipColor;
    [Header("put from smallest to largest ships 0:small 1:med 2:large")]
    public GameObject[] sizes;
}
[Serializable]
public struct ShipProjectileArray
{
    public ShipColor shipColor;
    [Header("put Laser Circle Square")]
    public GameObject[] projectilesToUse;
}
public enum ShootPatternType {
    Arc,
    Linear
}
public struct PatternInfo
{
    public List<Vector2> posArr;
    public List<float> zRotationArr;
    // consturctor
    public PatternInfo(List<Vector2> positions, List<float> rotations)
    {
        this.posArr = positions;
        this.zRotationArr = rotations;
    }
}