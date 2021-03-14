using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundManager : MonoBehaviour
{
    public static bool sxfSoundManager;
    public AudioSource caminar, espada, golpe, dañoHeroe, GameOver;

    // Start is called before the first frame update
    private void Start()
    {
        //sfxManagerCreate();
    }

    public void sfxManagerCreate()
    {
        if (!sxfSoundManager)
        {
            sxfSoundManager = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
