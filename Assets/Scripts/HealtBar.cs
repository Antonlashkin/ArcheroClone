using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] PlayerCharacter _health;

    private Camera _camera;


    void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
    }

    
    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged; 
    }

    private void OnHealthChanged(float valueAsPercanrage)
    {
        _healthBarFilling.fillAmount = valueAsPercanrage;
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0,180,0);
    }
}
