using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    GameObject door;
    GameObject reactorObject;
    public Vector3 posOffset;
    public float timeOffset;
    public bool openDoor;
    public bool reactor;
    private Vector3 velocity;


    void Update()
    {
        if (openDoor)
        {
            door = GameObject.FindGameObjectWithTag("Exit");
            transform.position = Vector3.SmoothDamp(transform.position, door.transform.position + posOffset, ref velocity, 0.1f);
        } else if (reactor)
        {
            reactorObject = GameObject.FindGameObjectWithTag("Reactor");
            transform.position = Vector3.SmoothDamp(transform.position, reactorObject.transform.position + posOffset, ref velocity, 0.1f);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }
        
    }
}
