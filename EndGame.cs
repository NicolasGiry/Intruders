using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Data").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        player.SavePlayer();
        SceneManager.LoadScene(0);
    }
}
