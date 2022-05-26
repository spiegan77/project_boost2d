using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTimer : MonoBehaviour
{
    
    new SpriteRenderer renderer;
    //Rigidbody2D rd;
    [SerializeField] float timeToWait = 3f;

    void Start()
    {
        GetComponent<DropTimer>().enabled = false;
        renderer = GetComponent<SpriteRenderer>();
        //rd = GetComponent<Rigidbody2D>();
        renderer.enabled = false;
        //rd.useGravity = false;
    }

    void Update()
    {
        if (Time.time > timeToWait)
        {
            //Debug.Log($"{Time.time} seconds have elapsed");
            renderer.enabled = true;
            //rd.useGravity = true;
        }
    }
}
