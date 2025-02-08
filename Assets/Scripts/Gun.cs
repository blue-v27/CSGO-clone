using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage, range, magAmmo, magMaxAmmo, magAmmoLeft;
    float ammoCounte, baseDamege;
    public static float ammoLeft, ammoTotal;

    private float timeBtwShots;
    public float startTimeBtwShots;

    bool sometingIsSelected;

    public Camera fpsCamera;
    public GameObject shottPoint, bullet;
    void Start()
    {
        baseDamege = damage;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (Input.GetKeyDown(KeyCode.R))
            Reload();

        ammoLeft = magAmmo;
        ammoTotal = magAmmoLeft;
        ammoCounte = (magMaxAmmo - magAmmo);
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();

            if (timeBtwShots <= 0)
            {

                if (Input.GetMouseButton(0) && magAmmo > 0)
                {
                    magAmmo--;

                    if (target != null)
                        target.takeDamage(damage);

                    Instantiate(bullet, shottPoint.transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }


                //    if (Input.GetButtonDown("Fire2"))
                //  {
                //      if (target != null)
                //     {
                //          target.selected();
                //      }
                //   }
                //  }

                //////////////
            }
            else
                timeBtwShots -= Time.deltaTime;
        }
       
    }

    void Reload()
    {
        if (magAmmoLeft > 0)
        {
            magAmmo += ammoCounte;
            magAmmoLeft -= ammoCounte;

            if (magAmmoLeft < magMaxAmmo)
                magAmmo += (magAmmoLeft - magAmmo);
        }
    }
}
