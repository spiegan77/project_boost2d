using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallSwitch : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Fuck fuck fuck");
        GameObject foo = GameObject.FindGameObjectWithTag("Wall");
        Destroy(foo, 1f);
        //GameObject foo = GameObject.FindGameObjectsWithTag("Friendly");
        //foreach (GameObject enemy in enemies)
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log("Wall");
        }
    }
}
