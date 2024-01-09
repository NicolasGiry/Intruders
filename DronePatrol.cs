using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class DronePatrol : MonoBehaviour
{
    public GameObject[] points;
    public Rigidbody2D rb;
    public float velocity;

    public bool detected;
    public Vector2[] playerPositions = new Vector2[100];
    private GameObject player;
    private int j = 0;
    public int k = 0;
    public GameObject exclamation;
    private bool exclamed;
    public Animator alarm;

    private Transform currentPoint;
    private Transform nextPoint;
    private Vector2 lookDirection;
    private Vector2 nextPointPosition;
    private float angle;
    private bool aller = true;
    private int i = 0;
    public bool coroutineLaunched = false;
    private int detectionCount;

    public Text gameOverText;
    public int health = 5;
   

    void Start()
    {
        Rigidbody2D myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
        myRigidbody.useFullKinematicContacts = true;
        transform.position = points[0].transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        currentPoint = points[i].transform;
        nextPoint = points[i+1].transform;
        nextPointPosition = nextPoint.position;
    }

    void Update()
    {
        if (health == 0)
        {
            StartCoroutine(DestroyDrone());
        }
    }

    void FixedUpdate()
    {
        if (!detected)
        {
            if (transform.position == nextPoint.position)
            {
                FindNextPoint();
            }
            else
            {
                lookDirection = nextPointPosition - rb.position;
                angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 180f;
                rb.rotation = angle;
                transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, velocity * Time.fixedDeltaTime);
            }
        } else
        {
            if (!coroutineLaunched)
            {
                velocity = 6;
                alarm.SetBool("Detected", true);
                Coroutine();
            }
            
            if ((Vector2) transform.position == playerPositions[k])
            {
                k++;
                if (k == 100)
                    k = 0;
            } else
            {
                if (!exclamed || detectionCount>1)
                {
                    lookDirection = playerPositions[k] - rb.position;
                    angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 180f;
                    rb.rotation = angle;
                    transform.position = Vector2.MoveTowards(transform.position, playerPositions[k], velocity * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void FindNextPoint()
    {
        if (aller)
        {
            i++;
            if (i==points.Length - 1)
            {
                aller = false;
                nextPoint = points[i - 1].transform;
            } else
            {
                nextPoint = points[i + 1].transform;
            }
            
        } else
        {
            i--;
            if (i == 0)
            {
                aller = true;
                nextPoint = points[i + 1].transform;
            }
            else
            {
                nextPoint = points[i - 1].transform;
            }
        }
        nextPointPosition = nextPoint.position;
    }

    IEnumerator FollowPlayer()
    {
        exclamation.transform.position = transform.position - new Vector3(1f, 0f, 0f);
        exclamation.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        exclamed = false;
        yield return new WaitForSeconds(0.3f);
        exclamation.SetActive(false);
        
        j = 0;
        k = 0;
        while (true)
        {
            if (j<100)
            {
                playerPositions[j] = player.transform.position;
                j++;
                yield return new WaitForSeconds(0.1f);
            } else
            {
                j = 0;
            }
        }
    }

    public void Coroutine()
    {
        StopAllCoroutines();
        detectionCount++;
        exclamed = true;
        StartCoroutine(FollowPlayer());
        coroutineLaunched = true;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            health--;
            detected = true;
            exclamed = true;
        }else if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(GameOver());
        }
    } 

    IEnumerator DestroyDrone()
    {
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
        alarm.SetBool("Detected", false);
        exclamation.SetActive(false);
    }

    IEnumerator GameOver()
    {
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Application.loadedLevel);
        gameOverText.enabled = false;
    }
}
