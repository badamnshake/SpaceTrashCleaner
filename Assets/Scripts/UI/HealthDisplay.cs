using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Image _healthBar;
    public float currentHealth = 50;
    public float maxHealth = 100;

    

    private void Update()
    {
        _healthBar.fillAmount = currentHealth / maxHealth;
    }
}