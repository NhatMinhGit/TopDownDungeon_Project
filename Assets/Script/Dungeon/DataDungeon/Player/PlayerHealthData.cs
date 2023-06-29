using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu]
public class PlayerHealthData : ScriptableObject
{
    public float currentHealth;

    [SerializeField] PlayerData _playerData;
    // Update is called once per frame
    [System.NonSerialized]
    public UnityEvent<float> healthChangeEvent;

    private void OnEnable()
    {
        currentHealth = _playerData.maxHealth-5;
        if (healthChangeEvent == null)
            healthChangeEvent = new UnityEvent<float>();
    }
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthChangeEvent.Invoke(currentHealth);
    }
}
