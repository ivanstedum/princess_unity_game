using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private float startingHealth;
   [SerializeField] private int playerDamage;
    public float currentHealth;
    
    private Animator anim;
    private bool dead;
    public int PlayerDamage
    {
        get
        {
            return playerDamage;

        }
    }
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime );
            
        }
    }
    }
    public void AddHealth(float _value)
    {
        //currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        currentHealth = currentHealth + _value;
    }
    private void ResetLevel() 
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Game Over");
    }
}
