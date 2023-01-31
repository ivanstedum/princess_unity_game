using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject patrolArea;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float attackDistance = 4f;
    private bool facingRight = false;
    private Transform playerTransform;
    private Animator enemyAnimator;

  void Start()
{
    enemyAnimator = GetComponent<Animator>();
    playerTransform = GameObject.FindWithTag("Player").transform;
    if (playerTransform == null)
    {
        Debug.LogError("No GameObject with tag 'Player' found.");
    }
}
    
private void Update()
{
    float minX = patrolArea.GetComponent<BoxCollider2D>().bounds.min.x;
    float maxX = patrolArea.GetComponent<BoxCollider2D>().bounds.max.x;
    float minY = patrolArea.GetComponent<BoxCollider2D>().bounds.min.y;
    float maxY = patrolArea.GetComponent<BoxCollider2D>().bounds.max.y;

    if (transform.position.x <= minX || transform.position.x >= maxX)
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    float targetX = facingRight ? maxX : minX;

    // Check if the player is within the patrol area
    if (playerTransform.position.x >= minX && playerTransform.position.x <= maxX &&
        playerTransform.position.y >= minY && playerTransform.position.y <= maxY)
    {
        // Follow the player
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
        
        // Trigger the running animation
        if (!enemyAnimator.GetBool("ghostDamage"))
        {
            enemyAnimator.SetBool("ghostMovesTowardsPlayer", true);
        }
    }
    else
    {
        // Move towards the patrol point
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), speed * Time.deltaTime);

        // Stop the running animation
        GetComponent<Animator>().SetBool("ghostMovesTowardsPlayer", false);
    }
}

}
