using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GotoCave : MonoBehaviour
{


    private static Intertistial intertistial;
    public string IrA = "";

    public string PosicionInicial = "";

    public void Start() {
        intertistial = GetComponent<Intertistial>();
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
   
        {
           
            FindObjectOfType<PlayerControler>().nextPlaceName = PosicionInicial;
          
            SceneManager.LoadSceneAsync(IrA);
            intertistial.RequestInterstitial();




        }
    }

   
}

