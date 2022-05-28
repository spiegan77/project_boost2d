using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallContact : MonoBehaviour
{
    [SerializeField] float LoadLevelDelay = 2f;
    [SerializeField] AudioClip crash;
    AudioSource audioSource;

    //public GameObject PlayerActive;

    //bool isTransitioning = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Ball Contact");
                StartCrashSequence();
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }
    void StartCrashSequence()
    {
        //isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        //crashParticles.Play();
        //GetComponent<Player>().enabled = false;
        //PlayerActive.SetActive(false);
        Invoke("ReloadScene", LoadLevelDelay);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
