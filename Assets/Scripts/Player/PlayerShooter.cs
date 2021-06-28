using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// should add a unity event that triggers on change on shipSize and color
public class PlayerShooter : MonoBehaviour
{

    // shooting points
    public Transform[] smallFp;
    public Transform[] mediumFp;
    public Transform[] largeFp;
    [SerializeField]
    private ShipProjectileArray[] shipProjectiles;
    public float bulletForce = 10f;

    // short ctr = 2;
    float timeSinceAttack = Mathf.Infinity;
    float timeBetweenAttacks = 0.5f;

    ShipColor shipColor;
    ShipSize shipSize;
    Transform[] currentFirePoints;
    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        OnShipChange();
        if (Input.GetKey(KeyCode.Mouse0) && timeSinceAttack > timeBetweenAttacks)
        {
            for (int i = 0; i < currentFirePoints.Length; i++)
            {
                GameObject bullet = Instantiate(shipProjectiles[(int)shipColor].projectilesToUse[(int)shipSize], currentFirePoints[i].position, currentFirePoints[i].rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletForce;
            }
            timeSinceAttack = 0;
        }
        else
        {
            timeSinceAttack += Time.deltaTime;
        }

    }
    void OnShipChange()
    {
        playerManager.GetShipSizeColor(out shipSize, out shipColor);
        switch (shipSize)
        {
            case ShipSize.Small:
                currentFirePoints = smallFp;
                break;
            case ShipSize.Medium:
                currentFirePoints = mediumFp;
                break;
            case ShipSize.Large:
                currentFirePoints = largeFp;
                break;
        }
    }

}

