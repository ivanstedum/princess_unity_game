using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float damage;
    [SerializeField] private float howLongSpikeIsUp;
    [SerializeField] private float rebootTime;
    [SerializeField] private float damageTime;
    private bool hasTakenDamage = false;
    public float coolDownTime;
    private Animator trapAnim;
    private bool spikeTriggered;
    private bool spikeActive;
    
    void Start()
    {
    
        trapAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        coolDownTime += Time.deltaTime;
        if(coolDownTime >= rebootTime)
        {
            coolDownTime = 0;
            StartCoroutine(ActivateSpike());
        }
    
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        
        Debug.Log(other.collider.tag);
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            
            StartCoroutine(DamagePlayer(player));
        }
    }

    private IEnumerator ActivateSpike()
    {
    
        trapAnim.SetBool("spikeActivated", true);

        //Wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(howLongSpikeIsUp);
        spikeActive = false;
        spikeTriggered = false;
        trapAnim.SetBool("spikeActivated", false);

    }
    private IEnumerator DamagePlayer(PlayerHealth _player)
    {
        if (!hasTakenDamage)
        {
            hasTakenDamage = true;
            yield return new WaitForSeconds(damageTime);
            _player.TakeDamage(damage);
            hasTakenDamage = false;
        }
    }
    
}
