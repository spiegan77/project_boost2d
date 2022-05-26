using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallSwitch : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] AudioClip success;

    AudioSource audioSource;

    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTransitioning) { return; }

        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GameObject foo = GameObject.FindGameObjectWithTag("Wall02");
        Destroy(foo, 1f);
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Wall")
    //    {
    //        Debug.Log("Wall");
    //    }
    //}
}
