using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] GameObject dieMenu;

    [SerializeField] PlayerData _playerData;

    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    //Khai báo animation
    Animator animator;

    List<RaycastHit2D> castCollisons = new List<RaycastHit2D>();//

    bool canMove = true;




    // [SerializeField] List<ItemBase> ItemsEquipped = new List<ItemBase>();


    // Start is called before the first frame update
    void Start()
    {
        // khai báo rb là component RigidBody2D
        rb = GetComponent<Rigidbody2D>();
        
        // khai báo animator là component Animator
        animator = GetComponent<Animator>();

        // khai báo spriteRenderer là component SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        _playerData.currentHealth = _playerData.maxHealth;
    }



    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                //---Trượt qua bề mặt ngăn cản ---//
                if (!success && movementInput.x > 0 /* movementInput.x > 0 dùng để xác định có vật để dùng animation lại*/ )
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            // Chỉnh hướng cho animation 
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                

            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
              
            }
        }
        
        Debug.LogError(_playerData.currentHealth);
        if(_playerData.currentHealth <= 0)
        {
            dieMenu.SetActive(true);
        }
    }


    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            //Di chuyen

            int count = rb.Cast(direction, movementFilter, castCollisons, moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
        

            if (count == 0)
            {
         
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }

            //----//
        }
        else
        {
     
            return false;
        }
    }



    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    
    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {
        LockMovement();
        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
        
    }
   
    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement() 
    {
        canMove = true;
    }
    
}
