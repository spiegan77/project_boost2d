using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector2 startingPosition;
    [SerializeField] Vector2 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; //continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSineWave = Mathf.Sin(cycles * tau);  // -1 to 1

        movementFactor = (rawSineWave + 1f) / 2f; // recalculated to go from 0 to 1 for cleanliness

        Vector2 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
