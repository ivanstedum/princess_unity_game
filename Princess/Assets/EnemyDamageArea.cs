using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inEnemyDamageArea = false;
    public bool InEnemyDamageArea
    {
        get
        {
            return inEnemyDamageArea;
        }
    }
    void Start()
    {
     Debug.Log("what");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inEnemyDamageArea = true;

        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        inEnemyDamageArea = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
