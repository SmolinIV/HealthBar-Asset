using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _targetHealth;

    protected float _lastShowingHealth;

    public void OnDisable()
    {
        _targetHealth.HealthChaged -= UpdateHealthBar;
    }

    protected void Start()
    {
        _lastShowingHealth = _targetHealth.CurrentHealth;

        _targetHealth.HealthChaged += UpdateHealthBar;
    }

    public void ChangeCurrentHealth(int currentHealth)
    {
        _currentHealth = currentHealth;
    }

    protected abstract void UpdateHealthBar();
}
