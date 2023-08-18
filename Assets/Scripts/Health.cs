using UnityEngine;
using System;

public class Health
{
    private float currentHealth;
    private float maxHealth;

    private float healthRegenRate;


    public float GetHealth()
    {
        return currentHealth;
    }
    public void SetHealth(float value)
    {
        if(value > maxHealth || value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), $"Vald range for...");

        currentHealth = value;
    }
    //these can have the same name because they have different paramters, and the compiler can distinguish
    public Health(float _maxHealth, float _healthRegenRate, float _currentHealth)
    {
        maxHealth = _maxHealth;
        healthRegenRate = _healthRegenRate;
        currentHealth = _currentHealth;
    }

    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
    }
    public Health()
    {}

    public void RegenHealth()
    {
        //why multiply by time.deltatime??
        AddHealth(healthRegenRate * Time.deltaTime);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Max(currentHealth, currentHealth + value);
    }
    public virtual void DeductHealth(float amount)
    {}
}
