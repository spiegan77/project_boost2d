using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleThrust : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Not sure if I prefer this shorthand or not
        rb.AddRelativeForce(Vector2.up * mainThrust * Time.deltaTime); // rb.AddRelativeForce(new Vector2(0,1))
    }
}
