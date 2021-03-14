using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Nockback : MonoBehaviour
{ 
  [SerializeField] private float thrust;
[SerializeField] private float knockTime;

//public float damage;

private void OnTriggerEnter2D(Collider2D other)
{

    if (other.gameObject.CompareTag("Player"))
    {
        Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();

        if (hit != null)
        {
            Vector3 difference = hit.transform.position - transform.position;
            difference = difference.normalized * thrust;
            hit.DOMove(hit.transform.position + difference, knockTime);
            //hit.AddForce(difference, ForceMode2D.Impulse);

         


        }
    }
}


}
