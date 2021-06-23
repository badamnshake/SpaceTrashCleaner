using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPos;
    float startZ;
    float distanceFromSubject => transform.position.z - subject.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // var is read only & calcs value everytime its called
    Vector2 travel => (Vector2)cam.transform.position - startPos;
    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    private void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
    }

    private void Update()
    {
        Vector2 newPos = startPos + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
