using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject explosion;
    private int i = 0;

    void OnCollisionEnter2D (Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Drone")
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
        }
        else if (collision.gameObject.tag !="Player")
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            i++;
            // le projectile rebondi 3 fois avant de se détruire
            if (i==3)
            {
                Destroy(gameObject);
                i = 0;
            }
            
        }
    }
}
