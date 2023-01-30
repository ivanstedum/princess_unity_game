using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject patrolArea;
    [SerializeField]private float speed = 1f;
    private bool facingRight = false;

private void Update()
{
    float minX = patrolArea.GetComponent<BoxCollider2D>().bounds.min.x;
    float maxX = patrolArea.GetComponent<BoxCollider2D>().bounds.max.x;


    if (transform.position.x <= minX || transform.position.x >= maxX)
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    float targetX = facingRight ? maxX : minX;
    transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), speed * Time.deltaTime);
}
}
