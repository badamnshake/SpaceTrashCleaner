using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipColor
{
    Yellow,
    Green,
    Black,
    Purple
}
[Serializable]
public struct ShipData
{
    public ShipColor shipColor;
    public GameObject[] sizes;
}
public enum ShipSize
{
    Small,
    Medium,
    Large
}