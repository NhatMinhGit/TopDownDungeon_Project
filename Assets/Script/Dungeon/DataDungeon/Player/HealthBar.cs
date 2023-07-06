using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private PlayerHealthData _playerHealthData;
    // Start is called before the first frame update
    void Start()
    {
        ChangeSliderValue(_playerHealthData.maxHP);
    }
    private void Update()
    {
        ChangeSliderValue(_playerHealthData.currentHP);
    }
    internal void AddHealth(int value)
    {
        _playerHealthData.currentHP += value;
    }

    private void ChangeSliderValue(float amount)
    {
        slider.value = ConvertFloatToFloatDemical(amount);
    }

    private float ConvertFloatToFloatDemical(float amount)
    {
        return (float)amount;
    }
    private void OnEnable()
    {
        _playerHealthData.healthChangeEvent.AddListener(ChangeSliderValue);
    }
    private void OnDisable()
    {
        _playerHealthData.healthChangeEvent.RemoveListener(ChangeSliderValue);
    }

    
}
