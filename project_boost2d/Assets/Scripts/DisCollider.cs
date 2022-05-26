using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisCollider : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] AudioClip success;

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
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GameObject foo = GameObject.FindGameObjectWithTag("Wall");
        Destroy(foo, 1f);

        //foo.GetComponent<Collider>().enabled = false; // This doesn't work. Best I can atm is destroy
    }
}
