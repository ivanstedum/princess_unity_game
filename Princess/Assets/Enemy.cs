using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private GameObject [] fireballs;
    [SerializeField] private Transform firepoint;
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private bool isAttacking = false;
    int facingDirection = 1;
    private Animator anim;
    private PlayerHealth playerHealth;

    [Header("Enemy Patrol")]
    [SerializeField] private GameObject patrolArea;
    [SerializeField] private float speed = 1f;
   //[SerializeField] private float attackDistance = 4f;
    private bool facingRight = false;
    private Transform playerTransform;
    private Animator enemyAnimator;
    
    public int FacingDirection
    {
        get
        {
            return facingDirection;

        }
    }
    
    public int EnemyDamage
    {
        get
        {
            return damage;

        }
    }
    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
                Debug.Log("shoot");
            }
        }
        else
        {
            EnemyPatrol();
        }


    }
    private void ShootFireBall()
    {
        int firebal = FindFireball();
        Debug.Log($"fireball is on: {firebal}");
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyFire>().ActivateProjectile();
        isAttacking = true;
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    public bool PlayerInSight()
    {
    
        if (transform.localScale.x < 0)
        {
            facingDirection = -1;
            
        }
        else
        {
            facingDirection = 1;
            
        }
        // -1 means direction is right, 1 is left
    RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + 1 * range * transform.right * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.right * facingDirection, 0, playerLayer);
        
        
        Debug.DrawRay(boxCollider.bounds.center + Vector3.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), Color.red, 5f);
        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<PlayerHealth>();

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + Vector3.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }


    //////////ENEMY PATROL !!!

    private void EnemyPatrol()
    {

        float minX = patrolArea.GetComponent<BoxCollider2D>().bounds.min.x;
        float maxX = patrolArea.GetComponent<BoxCollider2D>().bounds.max.x;
        float minY = patrolArea.GetComponent<BoxCollider2D>().bounds.min.y;
        float maxY = patrolArea.GetComponent<BoxCollider2D>().bounds.max.y;
        // this currently means that always have enemy patrol
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        float targetX = facingRight ? maxX : minX;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), speed * Time.deltaTime);
        // now we need to add code to make enemy move towards player
        if (playerTransform.position.x >= minX && playerTransform.position.x <= maxX &&
        playerTransform.position.y >= minY && playerTransform.position.y <= maxY)
        {
            speed = 0.8f;
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Face the player
            if (playerTransform.position.x > transform.position.x && !facingRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                facingRight = true;
            }
            else if (playerTransform.position.x < transform.position.x && facingRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                facingRight = false;
            }

        }
}
}