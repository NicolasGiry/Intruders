using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public int sceneIndex;
    public int nbBadges;

    public PlayerData(Player player)
    {
        sceneIndex = player.sceneIndex;
        nbBadges = player.nbBadges;
    }
}
