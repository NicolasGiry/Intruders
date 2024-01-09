using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
    public AudioClip doorSound;
    public AudioClip validationSound;
    public AudioSource audioSource;
    public GameObject camera;
    public GameObject timer;
    public int time;
    public int nextLevel;
    private GameObject audioManager;
    public Player player;
    public Animator fondu;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Data").GetComponent<Player>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        fondu = GameObject.FindGameObjectWithTag("Fondu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenExit()
    {
        StartCoroutine(OpenExitAnimation());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen && collision.gameObject.tag == "Player")
        {
            StartCoroutine(fonduExit());
            
        }
        
    }

    public IEnumerator OpenExitAnimation()
    {
        //Time.timeScale = 0.0f;
        camera.GetComponent<CameraFollow>().openDoor = true;
        isOpen = true;
        yield return new WaitForSeconds(1f);
        animator.SetBool("Open", true);
        audioSource.clip = validationSound;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        camera.GetComponent<CameraFollow>().openDoor = false;
        //Time.timeScale = 1.0f;
    }

    IEnumerator fonduExit()
    {
        fondu.SetBool("End", true);
        time = timer.GetComponent<Countdown>().GetTime();
        yield return new WaitForSeconds(0.5f);
        player.sceneIndex = nextLevel;
        player.SavePlayer();
        SceneManager.LoadScene(nextLevel);
        
    }
}
