using Inventory;
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    private float Health;
    private float Damage;
    [SerializeField] GameObject player;
    [SerializeField] GameObject portal;
    Rigidbody2D rigi;
    [SerializeField] LayerMask layerMask;
    [SerializeField]  EnemyData _enemyData;
    

    float distance;
    private void Start()
    {
        Damage = _enemyData.dmg;
        Health = _enemyData.hp;
        Health = SwordAttack.currentEHP;
        Debug.Log(Health);

        animator = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        rigi = this.gameObject.GetComponent<Rigidbody2D>();
        

    }
    private void Update()
    {
        Vector2 direction = player.transform.position - this.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, direction.sqrMagnitude, layerMask);

        if (hit.collider != null)
        {
            rigi.velocity = Vector2.zero;
            return;
        }
        CheckDistance();
        

    }
    private void CheckDistance()
    {

        Vector3 dir = player.transform.position - this.transform.position;
        //Debug.DrawRay(this.transform.position, dir, Color.red);
        
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        //Debug.Log(distance);
        if (distance <= _enemyData.detectRadius && distance > _enemyData.attackRadius)
        {
                this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, _enemyData.speed * Time.deltaTime);
                Move();
        }
    }
   
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0 && gameObject.name == "Enemy")
        {
            Defeated();
            Die();
            SpawnPortal();
        }
        else
        {
            Defeated();
            Die();
        }
        
    }

    public void Move()
    {
        animator.SetTrigger("Move");
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
    public void Defeated()
    {
        
        animator.SetTrigger("Defeated");
    }

    public void SpawnPortal()
    {
        Instantiate(portal, transform.position, Quaternion.identity);
    }
    public void Die()
    {
        //GetComponent<LootBag>().SpawnLoot(this.transform.position);
        Destroy(this.gameObject);
    }
}
