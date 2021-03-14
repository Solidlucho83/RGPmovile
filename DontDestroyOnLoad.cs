using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroyOnLoad : MonoBehaviour
{
    public static bool cameraCreated;

   



    // Start is called before the first frame update


    void Start()
    {
          


/*
        if (!PlayerControler.playerCreated)
        {
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
       if (!PlayerControler.cameraCreated)
        {
            cameraCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

      

    }


}
