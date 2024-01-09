using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicZone : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTrigger[] dialogues;
    public int currentDialogue = 0;
    public int referenceDialogue = 0;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            LaunchCinematic();
        }
    }

    public void LaunchCinematic()
    {
        dialogues[0].TriggerDialogue();

        if (currentDialogue != referenceDialogue)
        {
            referenceDialogue = currentDialogue;
            if (currentDialogue < dialogues.Length)
            {
                dialogues[currentDialogue].TriggerDialogue();
            }
            else
            {
                // fin
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}
