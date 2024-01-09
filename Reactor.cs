using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public Vector2 initialPosition;
    public int health = 3;
    public Animator animator;
    public AudioClip explosion;
    private GameObject audioManager;

    void Start()
    {
        //transform.position = initialPosition;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    void Update()
    {
        if (health==0)
        {
            StartCoroutine(DestroyReactor());
        }
    }

    public IEnumerator DestroyReactor()
    {
        audioManager.GetComponent<AudioManager>().PlaySound(explosion);
        animator.SetBool("Destroyed", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Projectile")
        {
            health--;
        }
    }
}
