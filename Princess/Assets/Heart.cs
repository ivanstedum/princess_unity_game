using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [Header("Heart Info")]
    [SerializeField] private GameObject player;
    [SerializeField] private float heartPlus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("LOVE ME");
            other.GetComponent<PlayerHealth>().AddHealth(heartPlus);
            gameObject.SetActive(false);

        }
        
    }
}
