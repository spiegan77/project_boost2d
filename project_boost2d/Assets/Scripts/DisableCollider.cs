using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    /*
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] AudioClip success;

    AudioSource audioSource;
    bool isTransitioning = false;
    */

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        //if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //Debug.Log("Player Tag");
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
        Collider2D foo = GameObject.FindGameObjectWithTag("Wall02").GetComponent<BoxCollider2D>();
        foo.enabled = false;
        GameObject.FindGameObjectWithTag("Wall02").GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        
        // Commented out the sounds and particles because I'm tired of hearing the same shit
        /*
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        */

    }
}
