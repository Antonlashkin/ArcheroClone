using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private GameObject moneyPrefab;
    private GameObject _money;
    private int _currentHealth;

    public event Action<float> HealthChanged;


    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangedHealth(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
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
        StartCoroutine(Money());
        Destroy(this.gameObject);
    }

    IEnumerator Money()
    {
        _money = Instantiate(moneyPrefab);
        _money.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        _money.transform.rotation = transform.rotation;
        yield return null;
    }
}
