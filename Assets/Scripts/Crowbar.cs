using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public float damage, range, magAmmo, magMaxAmmo, magAmmoLeft;
    

    bool sometingIsSelected;

    public Camera fpsCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();

            if (Input.GetButtonDown("Fire1") && magAmmo > 0)
            {
                magAmmo--;
                if (target != null)
                {
                    target.takeDamage(damage);
                }
            }

        }

        
    }

    void Reload()
    {
        if(magAmmoLeft > 0)
        {
            magAmmo += (magMaxAmmo - magAmmo);
            magAmmoLeft -= (magMaxAmmo - magAmmo);

            if(magAmmoLeft < magMaxAmmo)
            {
                magAmmo += (magAmmoLeft - magAmmo);
            }
        }
    }

}