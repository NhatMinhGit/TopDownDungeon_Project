using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    // Start is called before the first frame update
    public float maxHealth = 5;
    public float damage = 1;
    public float moveSpeed = 1f;
    public float currentHealth { get; set; }
}
