using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Vector2 startPosition;
    public AudioSource audioSource1;


    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            transform.position = startPosition;
            audioSource1.Play();
        }
    }
}
