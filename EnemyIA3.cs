using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA3 : MonoBehaviour
{
    public float speed;
    public float MeleeDistance;
    public float retreaDistance;
    public float DetectRadius;
    public float attackRadius;
    public Transform target;

    private Animator animator;
    private const string attackingState = "Attacking";
    private const string walkingState = "Walking";





    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= DetectRadius)
        {
            if (Vector2.Distance(transform.position, target.position) > MeleeDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                StartCoroutine(knockCo());
            }
            else if (Vector2.Distance(transform.position, target.position) > MeleeDistance && Vector2.Distance(transform.position, target.position) > retreaDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, target.position) > retreaDistance)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }

            //Atack Melee

            else if (Vector3.Distance(target.position, transform.position) <= DetectRadius
            && Vector3.Distance(target.position, transform.position) <= attackRadius)
            {

                StartCoroutine(knockCo());
            }
        }
    }


       
    public IEnumerator knockCo() { 

        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);

    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MeleeDistance);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, DetectRadius);
        Gizmos.DrawWireSphere(transform.position, retreaDistance);

    }

}
