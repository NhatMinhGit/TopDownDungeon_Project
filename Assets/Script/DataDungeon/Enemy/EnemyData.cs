using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public float hp ;
    public float dmg ;
    public float speed = (float)0.5;
    public float detectRadius = (float)0.7;
    public float attackRadius = (float)0.2;
}
