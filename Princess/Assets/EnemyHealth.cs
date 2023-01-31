using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    private Animator enemyAnimator;
    private bool isDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.collider.CompareTag("Player"))
        {
            Animator playerAnimator =  other.collider.GetComponent<Animator>();
            AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        
            if (stateInfo.IsName("princess-slash"))
                {
                    
                    health -= damage;
                    EnemyDamage();
                    if (health <= 0)
                    {
                        enemyAnimator.SetBool("ghostDeath", true);
                    }
                }
     
        
        }
    }

    private void EnemyDamage()
    {
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
