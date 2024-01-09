using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Data").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
