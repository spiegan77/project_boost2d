using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    float fractionPos;


    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + new Vector3(5, 0, 0);
    }

    void Update()
    {
        fractionPos += 0.01f;
        transform.position = Vector3.Lerp(startPos, endPos, fractionPos);

        //This works if there's something to collide with
        //transform.position += transform.right * Time.deltaTime;
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //    //if (isTransitioning) { return; }

    //    switch (collision.gameObject.tag)
    //    {
    //        case "Player":
    //            Debug.Log("Player Tag");
    //            MoveSquare();
    //            break;
    //        default:
    //            Debug.Log("Default Case");
    //            break;
    //    }
    //}

    //private void MoveSquare()
    //{
    //    fractionPos += 0.01f;
    //    GameObject foo = GameObject.FindGameObjectWithTag("MovingSwitch");
    //    foo.transform.position = Vector3.Lerp(startPos, endPos, fractionPos);
    //}
}
