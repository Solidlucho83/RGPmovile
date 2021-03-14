using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class UIManager : MonoBehaviour
{
    public Slider playerHealtBar;
    /* public Text playerHealtText;*/

    public HealtManager playerHealtManager;

    public static bool uimanagerCreated;

     void Start()
    {
        //isUIMANAGERCREATE();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealtBar.maxValue = playerHealtManager.maxHealth;
        playerHealtBar.value = playerHealtManager.currentHealth;

       /* StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(playerHealtManager.currentHealth);
        sb.Append("/");
        sb.Append(playerHealtManager.maxHealth);
        playerHealtText.text = sb.ToString();*/
    }

    public void isUIMANAGERCREATE()
    {
        if(!uimanagerCreated)
        {
            uimanagerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
