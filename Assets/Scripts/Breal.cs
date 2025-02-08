using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breal : MonoBehaviour
{

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "player" && collision.collider.tag == "player")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    public void Fall()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

}
