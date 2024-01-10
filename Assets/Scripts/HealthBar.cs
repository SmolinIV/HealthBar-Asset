using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private bool _isNumericalIndicatorOn = true;
    [SerializeField] private bool _isSmoothnessOn = true;

    [SerializeField] private TMP_Text _numericalIndicator;
    [SerializeField] private int _smoothnessCoefficient = 1;

    private Slider _slider;

    private int _maxHealth = 0;
    private int _currentHealth = 0;
    private float _lastShowingHealth = 0;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        if (!_isNumericalIndicatorOn)
            _numericalIndicator.enabled = false;

        if (_target.TryGetComponent(out Health health))
        {
            _maxHealth = health.MaxHealth;
            _slider.maxValue = _maxHealth;

            _currentHealth = health.CurrentHealth;
            _slider.value = _lastShowingHealth = _currentHealth;
        }
    }

    private void Update()
    {
        if (_lastShowingHealth != _currentHealth)
        {
            if (_isNumericalIndicatorOn)
                UpdateNumericalIndicator();

            SetSliderPosition();
        }
    }

    public void IncreaseCurrentHealth(int healingPoints)
    {
        _currentHealth += healingPoints;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void DecreaseCurrentHealth(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
    }

    public void SetMaxHealth()
    {
        _maxHealth = _currentHealth;
        _slider.maxValue = _maxHealth;
    }

    private void UpdateNumericalIndicator()
    {
        _numericalIndicator.text = _currentHealth.ToString() + "/" + _maxHealth.ToString();
    }

    private void SetSliderPosition()
    {
        if (_isSmoothnessOn)
        {
            _slider.value = Mathf.MoveTowards(_lastShowingHealth, _currentHealth, _smoothnessCoefficient * Time.deltaTime);
        }
        else
        {
            _slider.value = _currentHealth;
        }

        _lastShowingHealth = _slider.value;
    }

}
