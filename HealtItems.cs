using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtItems : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject particulas;
   

    public GameObject hitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag.Equals("Player"))
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            player.gameObject.GetComponent<HealtManager>().UpdateMaxHealt(maxHealth);

            if (player != null)
            {
                currentHealth = maxHealth;
                Destroy(gameObject);
                Instantiate(particulas, hitPoint.transform.position, hitPoint.transform.rotation);
                Destroy(GameObject.Instantiate(particulas));
                


            }
        }
    }
}
