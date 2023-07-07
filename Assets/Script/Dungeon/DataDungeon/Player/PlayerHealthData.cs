using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu]
public class PlayerHealthData : ScriptableObject
{
    public float currentHP,maxHP;
    [SerializeField] PlayerData _playerData;
    // Update is called once per frame
    [System.NonSerialized]
    public UnityEvent<float> healthChangeEvent;

    private void OnEnable()
    {
        maxHP = _playerData.maxHealth;
        currentHP = _playerData.maxHealth;
        if (healthChangeEvent == null)
            healthChangeEvent = new UnityEvent<float>();
    }
    
    public void DecreaseHealth(float amount)
    {
        currentHP -= amount;
        healthChangeEvent.Invoke(_playerData.currentHealth);
        _playerData.currentHealth = currentHP;
        //Debug.Log(_playerData.currentHealth);
    }

    
}
