using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dText;
    public TextMeshProUGUI UIdText;
    
    

    public GameObject dBox;
  
    public bool dialogActive;

    public string[] dialogLines; //arrays of lines of texts
    public int currentLine;

    private PlayerController thePlayer;
   
    void Start()
    {
    
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        

        if (dialogActive && Input.GetMouseButtonDown(0)) //Input.Get..Up (action will happen when key/finger is released) can be implemented on activation for buttons for example.
        {
            //dBox.SetActive(false);
            //dialogActive = false;
            currentLine++;
        }

        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0; 
            thePlayer.canMove = true;
        }

        dText.text = dialogLines[currentLine];
        UIdText.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
        UIdText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
        
    }
    
}
