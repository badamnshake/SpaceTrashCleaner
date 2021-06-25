using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ShipData[] shipSprites;
    public ShipColor shipColor;
    public ShipSize shipSize;
    ShipSize currentShipSize = ShipSize.Null;
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
        // to be optimized
        for (int i = 0; i < shipSprites.Length; i++)
        {
            if (shipSprites[i].shipColor == shipColor)
            {
                if (currentShipSize != ShipSize.Null)
                {
                    currentShip.sizes[(int)currentShipSize].SetActive(false);
                }
                shipSprites[i].sizes[(int)shipSize].SetActive(true);
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
    public void GetShipSizeColor(out ShipSize size, out ShipColor color)
    {
        size = this.currentShipSize;
        color = currentShip.shipColor;
    }
}
