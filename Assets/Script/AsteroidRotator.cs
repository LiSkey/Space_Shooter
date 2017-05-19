using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotator : MonoBehaviour {

    private Rigidbody rb;

    public float rotateFactor;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotateFactor;

    }

}
