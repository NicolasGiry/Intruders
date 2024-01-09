using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera camera;
    private Vector2 movement;
    private Vector2 mousePosition;
    private Vector2 lookDirection;
    public float velocity;
    public float horizontalSpeed = 1f;
    public float v;
    private float angle;

    public bool isCinematic;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // Cinematique
            Cursor.visible = false;
        }
    }

    void FixedUpdate()
    {
        if (isCinematic)
        {
            rb.rotation = 0f;
        } else
        {
            lookDirection = mousePosition - rb.position;
            angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            if (movement.y > 0)
            {
                transform.position += transform.up * velocity * Time.fixedDeltaTime;
            }
            if (movement.y < 0)
            {
                transform.position -= transform.up * velocity * Time.fixedDeltaTime;
            }
            if (movement.x > 0)
            {
                transform.position += transform.right * velocity * Time.fixedDeltaTime;
            }
            if (movement.x < 0)
            {
                transform.position -= transform.right * velocity * Time.fixedDeltaTime;
            }
        }
        
    }
}
