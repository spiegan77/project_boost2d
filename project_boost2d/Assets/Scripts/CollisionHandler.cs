using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadLevelDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;


    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisable = false;

    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; // toggle collision
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTransitioning || collisionDisable){return;}

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Deal");
                break;
            case "Obstacle":
                Debug.Log("This is an Obstacle");
                break;
            case "Finish":
                Debug.Log("I'm finish. like the crackers");
                StartSuccessSequence();
                break;
            case "Start":
                //GroundExplode();
                LoadFirstLevel();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    // I used this code for the Start Menu, but now use the tags for the disappearing floor
    void StartMenu()
    {
        SceneManager.LoadScene(1);
    }

    void LoadFirstLevel()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Player>().enabled = false;
        Invoke("StartMenu", LoadLevelDelay);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Player>().enabled = false;
        Invoke("LoadNextLevel", LoadLevelDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Player>().enabled = false;
        Invoke("ReloadScene", LoadLevelDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        /*
        NOTE: I think all I need to do is Comment out the following code
        in order to progress to the Game Over screen
        UPDATED NOTE: I don't actually need to comment out the following code, but probably should
        */
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    //Disabled because I couldn't get the fucking Follow Camera Active State to Switch
    /*
void GroundExplode()
{
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Friendly");
    foreach(GameObject enemy in enemies)
    {
        Destroy(enemy);
    }
    GameObject starty = GameObject.FindGameObjectWithTag("Start");
    Destroy(starty);
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(success);
    successParticles.Play();
    GetComponent<Player>().enabled = false;
}
*/
}
