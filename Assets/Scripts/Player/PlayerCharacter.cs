using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private GameObject gameOverScreen;
    private int _currentHealth;
    public event Action<float> HealthChanged;


    void Start()
    {
        _currentHealth = _maxHealth; 
    }

    public void ChangedHealth(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0 )
        {
            Death();
        }
        else
        {
            float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Destroy(this.gameObject);
        if (!gameOverScreen.activeSelf)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
}
