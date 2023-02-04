using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private EnemyPatrol EnemyPatrol;
    [SerializeField] private GameObject enemy;
    void Start()
    {
    
        EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
        if (EnemyPatrol == null)
    {
        Debug.LogError("EnemyPatrol component not found!");
        return;
    }
        
    }

    // Update is called once per frame
   void Update()
{
    EnemyPatrol = enemy.GetComponent<EnemyPatrol>();
    Debug.Log($"Enemy Patrol : {EnemyPatrol.EnemyFacingRight}");
    DirectionOfFireBall();
}
private void DirectionOfFireBall()
{
    if (EnemyPatrol.EnemyFacingRight)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    else if (!EnemyPatrol.EnemyFacingRight)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}



}
