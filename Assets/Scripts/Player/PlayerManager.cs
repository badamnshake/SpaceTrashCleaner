using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IHealth
{
    [SerializeField]
    private ShipData[] shipSprites;
    public ShipColor shipColor;
    public ShipSize shipSize;
    ShipSize currentShipSize = ShipSize.Null;
    ShipData currentShip;


    // health thingies
    [SerializeField]
    private float[] levelMaxHealth;
    float maxHealth;
    float healthAddOn = 0; /// extra health from powerups works as extenstion to maxHealth
    float currentHealth;

    void Start()
    {
        ChangeSprite();
        UpdateMaxHealth();
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
            UpdateMaxHealth();
        }
    }


    // health interface
    public void GetShipSizeColor(out ShipSize size, out ShipColor color)
    {
        size = currentShipSize;
        color = currentShip.shipColor;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }


    public void Restore(float percentageFraction)
    {
        float totalValue = currentHealth + maxHealth * percentageFraction;
        if (totalValue > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += maxHealth * percentageFraction;
        }
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }
    void UpdateMaxHealth()
    {
        maxHealth = levelMaxHealth[(int)currentShipSize] + healthAddOn;
    }
    void UpdateHealthAddon(float addOn)
    {
        healthAddOn += addOn;
    }
}
