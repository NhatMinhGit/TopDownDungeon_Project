using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    Vector2 rightAttackOffset;

    public GameObject player;

    //Singleton 
    [SerializeField] PlayerData _playerData;

    [SerializeField] EnemyData _enemyData;
    float dmg;
    float EnemyHealth;
    public static float currentEHP;
    



    private void Start()
    {
        dmg = _playerData.damage;
        EnemyHealth = _enemyData.hp;
        
        //Debug.Log(dmg);
    }
    private void Update()
    {
        rightAttackOffset = player.transform.position;
    }



    public void AttackRight()//Khi di chuyển sang phải thì rightAttackOffset sẽ dương  
    {
        print("Right");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3 (rightAttackOffset.x + (float)0.4, rightAttackOffset.y);
    }
    public void AttackLeft()//Khi di chuyển sang phải thì rightAttackOffset sẽ âm
    {
        print("Left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3( rightAttackOffset.x - (float)0.4, rightAttackOffset.y);
        //Debug.Log(transform.localPosition);
    }


    
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //Khi chém trúng Enemy thì Enemy sẽ bị trừ damage
    {
        if(other.tag == "Enemy" || other.tag == "Boss")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
            //Debug.Log(dmg);
        }
        currentEHP = EnemyHealth;

    }

    
}
