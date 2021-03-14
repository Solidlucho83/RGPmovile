using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public static bool joystickNoDestroy;
   

  
    private void Start()
    {
        joystickCreate();
    }

    public void joystickCreate()
    {
        if (!joystickNoDestroy)
        {
            joystickNoDestroy = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

