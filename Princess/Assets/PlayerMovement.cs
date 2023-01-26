using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    
    // Start is called before the first frame update
    public float jumpHeight;
    private Animator anim;
    private SpriteRenderer sprite;

    void Start()
    {
        
        Debug.Log("Hello, world");
        playerRb =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector3(xDirection * 7f, playerRb.velocity.y, 0);
        if (Input.GetButtonDown("Jump"))
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x , jumpHeight, 0);
        }

        updateAnimationState(xDirection);
    }

    void updateAnimationState(float xDirection)
    {
    

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
}
