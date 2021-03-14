using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA1 : MonoBehaviour
{
    public Transform target;
    public float DetectRadius;
    /*public float attackRadius;*/
    public Transform homePosition;

  
    void Start()
    {
      
        target = GameObject.FindGameObjectWithTag("Player").transform;
       

    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= DetectRadius
           /* && Vector3.Distance(target.position, transform.position) >= attackRadius*/)
                {
            transform.position = Vector3.MoveTowards(transform.position,
                target.position, 0.4f * Time.deltaTime );
        }
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, DetectRadius);
        /*Gizmos.DrawWireSphere(transform.position, attackRadius);*/

    }
}
