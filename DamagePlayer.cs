using Cinemachine.Utility;
using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamagePlayer : MonoBehaviour
{

    public int damage;
    
    public float Knocktime;

    public GameObject particulas;

    public GameObject hitPoint;
    // Start is called before the first frame update
    private SFXSoundManager SFXSoundManager;
    void Start()
    {
        SFXSoundManager = FindObjectOfType<SFXSoundManager>();
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag.Equals("Player"))
            {
                Rigidbody2D enemy = collision.gameObject.GetComponent<Rigidbody2D>();
                enemy.gameObject.GetComponent<HealtManager>().DamageCharacter(damage);

                if (enemy != null)
                {

                SFXSoundManager.dañoHeroe.Play();
                    StartCoroutine(knockCo(enemy));
                    Instantiate(particulas, hitPoint.transform.position, hitPoint.transform.rotation);
                    Destroy(GameObject.Instantiate(particulas));

                }
            }

        }
    
         
        
   private IEnumerator knockCo(Rigidbody2D enemy)
{
    if (enemy != null)
    {
        yield return new WaitForSeconds(Knocktime);
        enemy.velocity = Vector2.zero;


    }
}
}

 /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.tag.Equals("Player"))
        {

            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
          
            collision.gameObject.GetComponent<HealtManager>().DamageCharacter(damage);

            Instantiate(particulas, hitPoint.transform.position, hitPoint.transform.rotation);
           
            Vector2 diffence = (collision.gameObject.transform.position - transform.position).normalized * knockbackForce ;
            
            /*collision.gameObject.transform.position  = new Vector2(transform.position.x + diffence.x  ,  transform.position.y + diffence.y);
            player.AddForce( new Vector2(transform.position.x + diffence.x  ,  transform.position.y + diffence.y));








        }
    }*/


   



