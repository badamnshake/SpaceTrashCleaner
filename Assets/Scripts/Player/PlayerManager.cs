using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ShipData[] shipSprites;
    public ShipColor shipColor;
    public short shipSize;
    short currentShipSize = -1;
    ShipData currentShip;
    void Start()
    {
        ChangeSprite();
    }

    void Update()
    {
        CheckVars();
    }
    void ChangeSprite()
    {
        for (int i = 0; i < shipSprites.Length; i++)
        {
            if (shipSprites[i].shipColor == shipColor)
            {
                if (currentShipSize >= 0)
                {
                    currentShip.sizes[currentShipSize].SetActive(false);
                }
                shipSprites[i].sizes[shipSize].SetActive(true);
                currentShip = shipSprites[i];
                currentShipSize = shipSize;
            }
        }

    }
    void CheckVars()
    {
        if (currentShip.shipColor != shipColor || currentShipSize != shipSize)
        {
            ChangeSprite();
        }
    }
}
