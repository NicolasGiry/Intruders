using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject firePrefab;
    public AudioClip blaster;
    public float fireForce = 20f;
    private GameObject player;
    public GameObject audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !player.GetComponent<PlayerMovement>().isCinematic)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager.GetComponent<AudioManager>().PlaySound(blaster);
        var fire = (GameObject) Instantiate(firePrefab, firePoint.position, firePoint.rotation);
        if (fire==null)
        {
            Debug.Log("null");
        } else
        {
            Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            Destroy(fire, 2f);
        }

        
    }
}
