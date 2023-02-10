using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int facingDirection= enemy.GetComponent<Enemy>().FacingDirection;
        if(facingDirection == -1)// ghost is facing right
        {
            Debug.Log("shouldnt be going in");
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
        else if(facingDirection == 1)
        {
            Debug.Log($"enemy is facing: {facingDirection} and {transform.localScale.x}");
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
       
    }
}
