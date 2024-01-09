using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentences;
    public Animator animator;
    public Cinematic cinematic;
    public Image avatarImage;
    public Text next;

    public AudioClip[] takes;
    public AudioSource speaker;
    int i = 0;

    void Start()
    {
        i = 0;
        sentences = new Queue<string> ();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        avatarImage.sprite = dialogue.avatar;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue ();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        if (takes != null && takes[i] != null)
        {
            speaker.clip = takes[i];
            speaker.Play();
            i++;
        }

        next.text = "";
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
        next.text = "v";

        
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        cinematic.currentDialogue++;
    }
}
