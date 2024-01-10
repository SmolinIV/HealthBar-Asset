using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = CurrentHealth = 100;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void Recover() => CurrentHealth = MaxHealth;
}