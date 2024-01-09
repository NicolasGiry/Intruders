using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Player player;
    public Texture2D cursor;
    public Vector2 hotSpot;
    public AudioSource audioSource;
    public AudioClip titleMusic;
    public Animator fondu;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = titleMusic;
        audioSource.Play();
        player = GameObject.FindGameObjectWithTag("Data").GetComponent<Player>();
        fondu = GameObject.FindGameObjectWithTag("Fondu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Play()
    {
        StartCoroutine(playFondu());
    }

    public void NewGame()
    {
        player.sceneIndex = 1;
        player.nbBadges = 0;
        player.SavePlayer();
        Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator playFondu()
    {
        fondu.SetBool("End", true);
        player.LoadPlayer();
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(player.sceneIndex);
        Cursor.SetCursor(cursor, hotSpot, CursorMode.Auto);
    }
}
