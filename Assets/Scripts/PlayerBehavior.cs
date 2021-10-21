using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerBehavior : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed = 1.5f;
    public Vector2 movement;
    private SortedDictionary<float, float> coordinates = new SortedDictionary<float, float>();

    [SerializeField] private GameObject apple;

    void Start()
    {
        coordinates.Add(-5.14f, -8.16f);
        coordinates.Add(-8.32f, -4.25f);
        coordinates.Add(-22.72f, -2.18f);
        coordinates.Add(-13.96f, 0.15f);
        coordinates.Add(-18.9f, 11.69f);
        coordinates.Add(14.34f, 9.8f);
        coordinates.Add(-29.21f, -12.77f);
        coordinates.Add(-26.81f, -6.53f);
        coordinates.Add(20.51f, -7.91f);
        SpawnApple();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void SpawnApple()
    {
        var random = new System.Random();

        if (ScoreScript.appleCounter == 3)
        {
            SceneManager.LoadScene("WinWindow");
        }

        bool appleSpawned = false;
        int prevIndex = -1;
        while (!appleSpawned)
        {
            int index = random.Next(coordinates.Count);
            while (index == prevIndex)
            {
                index = random.Next(coordinates.Count);
            }

            Vector3 applePosition =
                new Vector3(coordinates.Keys.ElementAt(index), coordinates.Values.ElementAt(index), 0f);
            Instantiate(apple, applePosition, Quaternion.identity);
            appleSpawned = true;

            prevIndex = index;
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