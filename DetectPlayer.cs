using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{
    public Text gameOverText;
    private DronePatrol dronePatrol;

    void Start()
    {
        dronePatrol = transform.parent.GetComponent<DronePatrol>();
    }

    void OnTriggerEnter2D(Collider2D collider) { 
        if (collider.gameObject.tag == "Player")
        {
            dronePatrol.coroutineLaunched = false;
            dronePatrol.detected = true;
        }
    }

    IEnumerator GameOver()
    {
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2f);
        gameOverText.enabled = false;
        Application.LoadLevel(Application.loadedLevel);
    }
}
