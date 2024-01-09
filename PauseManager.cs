using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    public Player player;

    void Awake()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        gameObject.GetComponent<Image>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Data").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Debug.Log("pause");
            if (!isPaused )
            {
                PauseGame();
            } else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        gameObject.GetComponent<Image>().enabled = false;
    }

    public void RestartGame()
    {
        ResumeGame();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitGame()
    {
        ResumeGame();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        Destroy(p);
        Destroy(Camera.main.GetComponent<AudioListener>());
        Destroy(Camera.main);
        SceneManager.LoadScene(0);
    }
}
