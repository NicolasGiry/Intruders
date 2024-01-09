using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTrigger[] dialogues;
    public int currentDialogue = 0;
    public int referenceDialogue = 0;
    public Animator fondu;
    public Player player;
    private GameObject countdown;
    int indexScene;
    public GameObject camera;
    private int currentSentence = 0;
    public Animator upStripe;
    public Animator downStripe;
    public Animator blink;
    private GameObject playerObject;


    // Start is called before the first frame update
    void Start()
    {

        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.GetComponent<PlayerMovement>().isCinematic = true;
        indexScene = SceneManager.GetActiveScene().buildIndex;
        dialogues[0].TriggerDialogue();
        // arret du chrono le temps de la cinematique
        if (indexScene == 2)
        {
            upStripe.SetBool("Open", true);
            downStripe.SetBool("Open", true);
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            countdown = GameObject.FindGameObjectWithTag("Countdown");
            countdown.GetComponent<Countdown>().pause = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialogue != referenceDialogue)
        {
            referenceDialogue = currentDialogue;
            if (currentDialogue < dialogues.Length)
            {
                dialogues[currentDialogue].TriggerDialogue();
            } else
            {
               
                // fin de la cinematique
                if ( indexScene == 1)
                    StartCoroutine(EndCinematic());
                // reprise du chrono
                else if (indexScene == 2) {
                    upStripe.SetBool("Open", false);
                    downStripe.SetBool("Open", false);
                    countdown.GetComponent<Countdown>().pause = false;
                    playerObject.GetComponent<PlayerMovement>().isCinematic = false;
                }
                    
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
            if (indexScene == 2)
            {
                if (currentSentence == 4)
                {
                    camera.GetComponent<CameraFollow>().reactor = true;
                } else if (currentSentence == 5)
                {
                    camera.GetComponent<CameraFollow>().reactor = false;
                    camera.GetComponent<CameraFollow>().openDoor = true;
                } else if (currentSentence == 6)
                {
                    camera.GetComponent<CameraFollow>().openDoor = false;
                }else if (currentSentence == 7)
                {
                    blink.SetBool("Blink", true);
                }else if (currentSentence == 8)
                {
                    blink.SetBool("Blink", false);
                }
            }
            currentSentence++;
        }
    }

    IEnumerator EndCinematic()
    {
        player = GameObject.FindGameObjectWithTag("Data").GetComponent<Player>();
        fondu.SetBool("End", true);
        yield return new WaitForSeconds(0.5f);
        Cursor.visible = true;
        player.sceneIndex = 2;
        player.SavePlayer();
        playerObject.GetComponent<PlayerMovement>().isCinematic = false;
        SceneManager.LoadScene(2);
    }
}
