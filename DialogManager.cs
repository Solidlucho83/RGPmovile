using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public bool dialogActive;
    public string[] DialogLine;
    public int CurrentDialogline;

    private PlayerControler playerController;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerControler>();
        
        
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            CurrentDialogline++;
        }
        if (CurrentDialogline >= DialogLine.Length)
        {
            dialogActive = false;
            DialogBox.SetActive(false);
            CurrentDialogline = 0;
            playerController.playerTalking = false;
            
        }
        else
        {
            DialogText.text = DialogLine[CurrentDialogline];
        }
    }

    public void ShowDialog(string[] lines)
    {
        dialogActive = true;
        DialogBox.SetActive(true);
        CurrentDialogline = 0;
        DialogLine = lines;
       playerController.playerTalking = true;

    }
}
