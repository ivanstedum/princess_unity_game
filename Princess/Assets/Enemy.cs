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

    int facingDirection = 1;
    private Animator anim;
    private PlayerHealth playerHealth;
    public int FacingDirection
    {
        get
        {
            return facingDirection;

        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
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
            }
        }


    }
    private void ShootFireBall()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyFire>().ActivateProjectile();
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
    private bool PlayerInSight()
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
}