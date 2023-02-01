using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    private Transform playerTransform;
    private Animator enemyAnimator;
    public bool isAttacking;
    private float cooldownTimer = Mathf.Infinity;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Vector3.Distance(transform.position, playerTransform.position) < 3 && cooldownTimer >= attackCooldown)
        {
            Debug.Log("cooldownTimer");
            Debug.Log(cooldownTimer);
            isAttacking = true;
            AnimationWhenAttacking();
            Debug.Log(enemyAnimator.GetBool("ghostAttacks"));
            Debug.Log(enemyAnimator.GetBool("ghostMovesTowardsPlayer"));
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
        enemyAnimator.SetBool("ghostMovesTowardsPlayer", true);
    }
}
