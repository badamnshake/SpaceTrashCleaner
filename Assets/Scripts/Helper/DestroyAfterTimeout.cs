using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimeout : MonoBehaviour
{
    public float destoryTimeout = 2f;
    void Start()
    {
        DestroyAfter(destoryTimeout);
    }

    IEnumerator DestroyAfter(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        Destroy(gameObject);
    }
}
