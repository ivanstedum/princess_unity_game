using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private EnemyPatrol EnemyPatrol;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed;
    private bool hit = false;
    private bool hitPlayer = false;
    public bool fhitsPlayer
    {
        get
        {
            return hitPlayer;
        }
    }
    public bool fireHitsSomething
    {
        get
        {
            return hit;
        }
    }
    private void Awake() {
        EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
        
    }
    void Start()
    {
    
        EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
        if (EnemyPatrol == null)
    {
        Debug.LogError("EnemyPatrol component not found!");
        return;
    }
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag!="enemy")
        {
            Debug.Log("NOT ENEMY");
            hit = true;
            if(other.tag == "Player")
            {
                hitPlayer = true;
            }

        }
        
    
    }
    

    
    // Update is called once per frame
   void Update()
{
    EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
    Debug.Log($"Enemy Patrol : {EnemyPatrol.EnemyFacingRight}");
} 
public void DirectionOfFireBall()
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    float xDirection = transform.localScale.x;
    
    if (EnemyPatrol.EnemyFacingRight)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        xDirection = transform.localScale.x;
    }
    else if (!EnemyPatrol.EnemyFacingRight)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        xDirection = transform.localScale.x;
    
    }

    float xMovement = speed * Time.deltaTime * xDirection;
    transform.Translate(new Vector2(xMovement, 0));
    Debug.Log($"Movement : {xMovement}");
}



}