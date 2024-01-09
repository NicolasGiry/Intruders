using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credit : MonoBehaviour
{
    private EndGame endgame;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);

        StartCoroutine(defilement());
        endgame = GameObject.FindGameObjectWithTag("Credit").GetComponent<EndGame>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator defilement()
    {
        while(transform.position.y<1500)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
            transform.position += new Vector3(0, 1, 0);
        }
        Destroy(Camera.main.GetComponent<AudioListener>());
        Destroy(Camera.main);
        endgame.End();
    }
}
