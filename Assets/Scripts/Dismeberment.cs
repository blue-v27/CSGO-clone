using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dismeberment : MonoBehaviour
{
    public GameObject head, body;

    public Rigidbody rb;

    public static bool iMadeCollison;
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

        if (collision.collider.tag == "blade")
        {
            head.transform.parent = null;
            body.transform.parent = null;
            iMadeCollison = true;
        }

    }

    public void Fall()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
