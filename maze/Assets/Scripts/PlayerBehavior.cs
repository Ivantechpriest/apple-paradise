using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY, moveSpeed;

    [SerializeField] private GameObject apple;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        SpawnApple();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    private void SpawnApple()
    {
        if (ScoreScript.appleCounter == 3)
        {
            SceneManager.LoadScene("WinWindow");
        }
        bool appleSpawned = false;
        while (!appleSpawned)
        {
            Vector3 applePosition = new Vector3(Random.Range(-24f, 18f), Random.Range(-8f, 8.5f), 0f);
            if ((applePosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(apple, applePosition, Quaternion.identity);
                appleSpawned = true;
            }
        }

        {
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        ScoreScript.appleCounter++;
        SpawnApple();
    }

    private void OnCollisionEnter2D(Collision2D door)
    {
        if (door.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene("WinWindow");
        }
    }
}