using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;

    void Start()
    {
        manager = FindObjectOfType<DialogManager>();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = false;
        }
    }

 
    void Update()
    {
        if(playerInTheZone && Input.GetButton("Fire2") || (Input.GetKey(KeyCode.Return)))
        {
            manager.ShowDialog(dialog);
        }
    }
}
