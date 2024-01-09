using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayer : MonoBehaviour
{
    private GameObject player;
    public Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = initialPosition;
    }
}
