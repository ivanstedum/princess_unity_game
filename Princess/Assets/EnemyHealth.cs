using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    private Animator enemyAnimator;
    private bool isDamaged = false;
    private EnemyDamageArea EnemyDamageArea;
    [SerializeField] private GameObject EnemyDamageAreaObj;
    [SerializeField] private Animator playerAnimator;
    public int EnemyHealthAmount
    {
        get
        {
            return health;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        EnemyDamageArea = EnemyDamageAreaObj.GetComponent<EnemyDamageArea>();
        
    }
    void Update()
    {
        
        if (EnemyDamageArea.InEnemyDamageArea)
        {
            attackingEnemy();
        }
    }
    // private void OnCollisionStay2D(Collision2D other) {
        
    //     if(other.collider.CompareTag("Player"))
    //     {
    //         Animator playerAnimator =  other.collider.GetComponent<Animator>();
    //         AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        
    //         if (stateInfo.IsName("princess-slash"))
    //             {
                    
    //                 health -= damage;
    //                 EnemyDamage();
    //                 if (health <= 0)
    //                 {
    //                     enemyAnimator.SetTrigger("ghostDeath");
    //                     EnemyDeath();
    //                 }
    //             }
    
        
    //     }
    // }
    private void attackingEnemy()
    {
        if(EnemyDamageArea.InEnemyDamageArea)
        {
            AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
            
          
            if (Input.GetButtonDown("Slash"))
                {
                    var ghostIsDying = enemyAnimator.GetBool("ghostDying");
                    Debug.Log($"Debug Current Ghost Dying: {ghostIsDying}");
                    if(enemyAnimator.GetBool("ghostDying"))
                    {
                        
                    }
                
                    else if (health - damage == 0 )
                    {
                        health -= damage;
                        enemyAnimator.SetTrigger("ghostDeath");
                        enemyAnimator.SetBool("isDying", true);
                        
                    }
                    
                    else if (health > 0)
                    {
                        Debug.Log("here");
                        health -= damage;
                        EnemyDamage();
                    }
                
                }
        }
    }

    private void EnemyDamage()
    {
        enemyAnimator.SetTrigger("hurt");
        Debug.Log("inside");
        enemyAnimator.SetBool("ghostMovesTowardsPlayer", false);
        enemyAnimator.SetBool("ghostDamage", true);
        isDamaged = true;
    }
    private void ResumeRun()
    {
        enemyAnimator.SetBool("ghostMovesTowardsPlayer", true);
        enemyAnimator.SetBool("ghostDamage", false);
    }
    private void EnemyDeath()
    {
        gameObject.SetActive(false);
    }


}
