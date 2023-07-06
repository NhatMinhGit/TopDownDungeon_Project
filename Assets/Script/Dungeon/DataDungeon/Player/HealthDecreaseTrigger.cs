using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecreaseTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EnemyData _enemyData;

    [SerializeField] PlayerHealthData _playerHealthData;

    private float EnemyDamage;
    // Update is called once per frame
    private void Awake()
    {
        EnemyDamage = _enemyData.dmg;

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            _playerHealthData.DecreaseHealth(EnemyDamage);
    }
}
