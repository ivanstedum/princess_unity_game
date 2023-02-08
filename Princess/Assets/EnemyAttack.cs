using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed;
    private Transform playerTransform;
    private Animator enemyAnimator;
    private EnemyFire enemyFire;
    private float enemyFacing;
    private bool canShootFire;
    
    public bool isAttacking;
    public float cooldownTimer;

    void Start()
    {
        cooldownTimer = attackCooldown;
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemyAnimator = GetComponent<Animator>();
        canShootFire = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(enemyAnimator.GetBool("isDying"));
        if(!enemyAnimator.GetBool("isDying"))
        {
            EnemyAttacking();

        }
        else
        {
            enemyAnimator.SetBool("ghostAttacks", false);
        }
    

        
    }
    private void EnemyAttacking()
    {
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer <= 0)
        {
            cooldownTimer = attackCooldown;
            enemyAnimator.Play("ghost-attack", -1, 0f);
        }
        else if(Vector3.Distance(transform.position, playerTransform.position) < 6)
        {
            Debug.Log("cooldownTimer");
            Debug.Log(cooldownTimer);
            isAttacking = true;
            AnimationWhenAttacking();
            if(canShootFire)
        {
            Debug.Log($"can shoot: {canShootFire}");
            ShootFireBall();
        }
            
        
            
        }
        else
        {
            AnimationNotAttacking();
            isAttacking = false;
        }
    }
    private void AnimationWhenAttacking()
    {
        
        enemyAnimator.SetBool("ghostAttacks", true);
        enemyAnimator.SetBool("ghostMovesTowardsPlayer", false);
        
        
        
    }
    private void AnimationNotAttacking()
    {
        enemyAnimator.SetBool("ghostAttacks", false);
    }
    private void canShootFireBall()
   {
        canShootFire = true;
        

        
   }
   private void  ShootFireBall()
   {
        //fireballs[0].transform.position = firePoint.position;
        enemyFire = fireballs[0].GetComponent<EnemyFire>();
        fireballs[0].transform.SetParent(null, true);
        fireballs[0].SetActive(true);
        fireballs[0].GetComponent<EnemyFire>().DirectionOfFireBall();
        Debug.Log($"enemy did hit something: {enemyFire.fireHitsSomething}");
        if(enemyFire.fireHitsSomething)

        {
            fireballs[0].SetActive(false);
        }
        

   }

}