using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    [SerializeField] private float jumpHeight;
    private Animator anim;
    private SpriteRenderer sprite;
    private CapsuleCollider2D ground;
    [SerializeField] private LayerMask jumpableGround;
    
    // have an array that contains all animation statea

    void Start()
    {
        
        Debug.Log("Hello, world");
        playerRb =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        ground = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector3(xDirection * moveSpeed, playerRb.velocity.y, 0);
        if (Input.GetButtonDown("Jump") && onGround())
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x , jumpHeight, 0);
            anim.SetTrigger("Jumping");
            
        }
    

        if (playerRb.velocity.y < -.1f){
            anim.SetBool("Falling", true);
        }
        if (onGround())
        {
            anim.SetBool("Falling", false);
        }
        updateAnimationState(xDirection);

    }


    void updateAnimationState(float xDirection)
    {
    
        if(Input.GetButtonDown("Slash"))
        {
            anim.SetTrigger("Slashing");
        }

        if (xDirection > 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = false;
        }
        else if (xDirection < 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = true;
        }
        else 
        {
            anim.SetBool("walking", false);
        }
        
    }

    private bool onGround()
    {
        
        return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
}
