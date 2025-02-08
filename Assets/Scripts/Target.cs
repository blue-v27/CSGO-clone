using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100;

    public GameObject pos, deathEffect;

    public Rigidbody rb;

    public float speed;

    bool wasSelected;

    public Camera fpsCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (wasSelected && Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void selected()
    {
        gameObject.transform.position = pos.transform.position;
        gameObject.transform.parent = pos.transform;
        rb.constraints = RigidbodyConstraints.FreezePosition;       
        wasSelected = true;

    }

    void Die()
    {
        Destroy(gameObject);
        Money.money += 300;
        Eleft.enemyLeft--;
        Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
    }

    public void Throw()
    {
        rb.AddForce(fpsCamera.transform.forward * speed, ForceMode.Impulse);
        gameObject.transform.parent = null;
        rb.constraints = RigidbodyConstraints.None;
    }
}
