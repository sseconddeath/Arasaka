using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("урон получен");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    void Die()
    {
        //сюда вставить код после смерти
        Debug.Log("Герой вмер");
    }
}
