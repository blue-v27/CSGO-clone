using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject Camera, Smok;

    float number = 0;

    public float Force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && number == 0)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Camera.transform.forward * Force, ForceMode.Impulse);
            gameObject.transform.parent = null;
            Smok.transform.parent = null;
            number++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Smok.SetActive(true);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
