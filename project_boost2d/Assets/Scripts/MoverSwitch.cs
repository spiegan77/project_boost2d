using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSwitch : MonoBehaviour
{
    public GameObject Manager;
    public GameObject Manager02;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Player":
                Debug.Log("Break Wall");
                MoveLerpSwitch();
                break;
            default:
                Debug.Log("Default Case");
                break;
        }
    }

    void MoveLerpSwitch()
    {
        //isTransitioning = true;
        //audioSource.Stop();
        //audioSource.PlayOneShot(success);
        //successParticles.Play();
        Manager02.SetActive(false);
        Manager.SetActive(true);
    }
}
