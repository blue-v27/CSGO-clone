using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;

    public Camera fpsCamera;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            rb.AddForce(fpsCamera.transform.forward * speed, ForceMode.Impulse);       
    }
}
