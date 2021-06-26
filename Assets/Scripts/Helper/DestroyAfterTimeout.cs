using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimeout : MonoBehaviour
{
    public float destoryTimeout = 2f;
    void Start()
    {
        Destroy(gameObject, destoryTimeout);
    }

}
