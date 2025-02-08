using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Aspawns, Bspawns, Midspawns;
    int RandomOptionA, RandomOptionB, RandomOptionMid, RandomSite;

    public Rigidbody rb;

    float range = 5, rangeSeeFwd = 10, rangeSeeRight = 7, moveSpeed = 10;

    float time = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomOptionA = Random.Range(0, Aspawns.Length);
        RandomOptionB = Random.Range(0, Bspawns.Length);
        RandomOptionMid = Random.Range(0, Midspawns.Length);
        RandomSite = Random.Range(0, 2);

        if (RandomSite == 0)
        {
            gameObject.transform.position = Aspawns[RandomOptionA].transform.position;
        }
        else if (RandomSite == 1)
        {
            gameObject.transform.position = Bspawns[RandomOptionB].transform.position;
        }
        else
        {
            gameObject.transform.position = Midspawns[RandomOptionMid].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Player.transform.position, time * Time.deltaTime);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "blade")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            RandomOptionA = Random.Range(0, Aspawns.Length);
            RandomOptionB = Random.Range(0, Bspawns.Length);
            RandomOptionMid = Random.Range(0, Midspawns.Length);

            if (RandomSite == 0)
            {
                gameObject.transform.position = Aspawns[RandomOptionA].transform.position;
            }
            else if (RandomSite == 1)
            {
                gameObject.transform.position = Bspawns[RandomOptionB].transform.position;
            }
            else
            {
                gameObject.transform.position = Midspawns[RandomOptionMid].transform.position;
            }
        }
       
       
    }

  /*  void followPlayer()
    {
        RaycastHit hitSee;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hitSee, rangeSeeFwd))
        {
            if (hitSee.collider.tag == "Player")
            {
                time = 1;

            }
        }

        RaycastHit hitSeeRight;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.right, out hitSeeRight, rangeSeeRight))
        {
            if (hitSeeRight.collider.tag == "Player")
            {
                time = 1;

            }
        }

        RaycastHit hitSeeLeft;
        if (Physics.Raycast(gameObject.transform.position, -gameObject.transform.right, out hitSeeLeft, rangeSeeRight))
        {
            if (hitSeeLeft.collider.tag == "Player")
            {
                time = 1;

            }
        }
    }*/
   
}
