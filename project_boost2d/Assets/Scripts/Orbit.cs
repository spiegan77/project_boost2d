using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;
    public GameObject target;
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0,0,1), rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0,0,1), rotationSpeed * Time.deltaTime);

    }
}
