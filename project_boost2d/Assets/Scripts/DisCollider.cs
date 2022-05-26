using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisCollider : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] AudioClip success;

    public GameObject Manager;
    public GameObject Manager02;

    AudioSource audioSource;
    //Collider m_Collider;
    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Fetch the GameObject's Collider (make sure it has a Collider component)
        //m_Collider = GetComponent<Collider>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Player":
                Debug.Log("Break Wall");
                WallDestroy();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        Debug.Log("default Case");
    }

    void WallDestroy()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GameObject foo = GameObject.FindGameObjectWithTag("Wall");
        Destroy(foo, 1f);
        Manager02.SetActive(false);
        Manager.SetActive(true);
    }
}
