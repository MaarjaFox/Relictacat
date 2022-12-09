using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;
    public string[] dialogueLines;
    private static HashSet<string> firstTimeSet = new HashSet<string>();

    public string singleRunKey;

    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //OnTriggerStay was actually implemented in a tutorial I watched
    {
        if(other.gameObject.name == "Player"  && firstTimeSet.Add(singleRunKey))
        {
            //dMan.ShowBox(dialogue);

            if(!dMan.dialogActive)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0; //currentLine reset back to 0
                dMan.ShowDialogue();
                

            }

        }
    }
    
}
