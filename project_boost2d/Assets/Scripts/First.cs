using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    bool isTransitioning = false;
    public GameObject Manager;
    //float timeToWait = 5f;

    void Start()
    {
        //for(int i = 0; i < 5; i++)
        //{
        //    Debug.Log("This is the first script");
        //}
        //Manager.SetActive(true);


    }

    private void Update()
    {
        // The code below works as expected. Now tie it to a collision
        //if (Time.time > timeToWait)
        //{
        //    Manager.SetActive(true);
        //}
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Bump that dump");
    //    Manager.SetActive(true);
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Player":
                Debug.Log("Break Wall");
                Manager.SetActive(true);
                // Delay here would require IEnumerator or Coroutine
                //if (Time.time > timeToWait)
                //{
                //    Manager.SetActive(true);
                //}
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence()
    {
        Debug.Log("Default");
    }
}
