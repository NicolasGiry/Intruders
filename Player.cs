using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int sceneIndex;
    public int nbBadges;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(this);

        sceneIndex = data.sceneIndex;
        nbBadges = data.nbBadges;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
