using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : EnemyDamage
{
      [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
    private GameObject enemy;
    private bool hit;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        enemy = GameObject.Find("Ghost");
    }

    public void ActivateProjectile()
    {
         gameObject.SetActive(true);

        int facingDirection= enemy.GetComponent<Enemy>().FacingDirection;
        if(facingDirection == -1)// ghost is facing right
        {
        
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
             speed = Mathf.Abs(speed);

        }
        else if(facingDirection == 1)
        {
           
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            speed = -Mathf.Abs(speed);

        }
        
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hit = true;
            Debug.Log("enemy");
            base.OnTriggerEnter2D(collision); //Execute logic from parent script first
            coll.enabled = false;
        
            gameObject.SetActive(false); //When this hits any object deactivate arrow

        }
        
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
     
//     private EnemyPatrol EnemyPatrol;
//     [SerializeField] private GameObject enemy;
//     [SerializeField] private float speed;

//     private bool hit = false;
//     private bool hitPlayer = false;
//     public bool fhitsPlayer
//     {
//         get
//         {
//             return hitPlayer;
//         }
//     }
//     public bool fireHitsSomething
//     {
//         get
//         {
//             return hit;
//         }
//     }
//     private void Awake() {
//         EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
        
//     }
//     void Start()
//     {
    
//         EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
//         if (EnemyPatrol == null)
//     {
//         Debug.LogError("EnemyPatrol component not found!");
//         return;
//     }
        
//     }
//     private void OnTriggerEnter2D(Collider2D other) 
//     {
//         if(other.tag!="enemy")
//         {
//             Debug.Log("NOT ENEMY");
//             hit = true;
//             if(other.tag == "Player")
//             {
//                 hitPlayer = true;
//             }

//         }
        
    
//     }
    

    
//     // Update is called once per frame
//    void Update()
// {
//     EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
//     Debug.Log($"Enemy Patrol : {EnemyPatrol.EnemyFacingRight}");
// } 
// public void DirectionOfFireBall()
// {
//     gameObject.SetActive(true);
    
//     Rigidbody2D rb = GetComponent<Rigidbody2D>();
//     float xDirection = transform.localScale.x;
    
//     if (EnemyPatrol.EnemyFacingRight)
//     {
//         transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
//         xDirection = transform.localScale.x;
//     }
//     else if (!EnemyPatrol.EnemyFacingRight)
//     {
//         transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
//         xDirection = transform.localScale.x;
    
//     }

//     float xMovement = speed * Time.deltaTime * xDirection;
//     transform.Translate(new Vector2(xMovement, 0));
//     Debug.Log($"Movement : {xMovement}");
// }




