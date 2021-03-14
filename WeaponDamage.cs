using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WeaponDamage : MonoBehaviour
{
    public int damage;
    public float thrust;
    public float Knocktime;

    public GameObject particulas;
  
    public GameObject hitPoint;
    // Start is called before the first frame update



    private SFXSoundManager SFXSoundManager;

    void Start()
    {
        SFXSoundManager = FindObjectOfType<SFXSoundManager>();
    }



        private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Rigidbody2D enemy = collision.gameObject.GetComponent<Rigidbody2D>();
            enemy.gameObject.GetComponent<HealtManagerEnemy>().DamageCharacter(damage);

            if (enemy != null)
            {
                SFXSoundManager.golpe.Play();
                Vector2 diffence = (collision.gameObject.transform.position - transform.position);
                diffence = diffence.normalized * thrust;
                enemy.AddForce(diffence, ForceMode2D.Impulse);
                StartCoroutine(knockCo(enemy));
                Instantiate(particulas, hitPoint.transform.position, hitPoint.transform.rotation);
                Destroy(GameObject.Instantiate(particulas));
               
            }
        }
        if (collision.gameObject.tag.Equals("Dragon"))
        {
            Rigidbody2D enemy = collision.gameObject.GetComponent<Rigidbody2D>();
            enemy.gameObject.GetComponent<HealtManagerEnemy>().DamageCharacter(damage);

            if (enemy != null)
            {
                SFXSoundManager.golpe.Play();
                Vector2 diffence = (collision.gameObject.transform.position - transform.position);
                diffence = diffence.normalized * thrust;
                enemy.AddForce(diffence, ForceMode2D.Impulse);
                StartCoroutine(knockCo(enemy));
                Instantiate(particulas, hitPoint.transform.position, hitPoint.transform.rotation);
                Destroy(GameObject.Instantiate(particulas));
          /*      StartCoroutine(Final(enemy));
                SceneManager.LoadSceneAsync("Final");*/

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
    private IEnumerator Final(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(5.0f);
            SceneManager.LoadSceneAsync("Final");



        }
    }

}



/*
            collision.gameObject.transform.position = new Vector2(transform.position.x + diffence.x, transform.position.y + diffence.y);

            Instantiate(particulas, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(GameObject.Instantiate(particulas));
                
        }

         
    }
}*/
