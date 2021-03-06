﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public Transform pistolDirection;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public int bulletsInMagazine = 10;

    public int magazines = 2;

    private Vector3 shift = new Vector3(0, 0.2f, 0);
    private bool canFire = true;


    UISingleton uISingleton;
    // Start is called before the first frame update
    void Start()
    {
        uISingleton = UISingleton.Instance;
        uISingleton.setBullets(bulletsInMagazine.ToString());
        uISingleton.setMagazines(magazines.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (bulletsInMagazine > 0 && canFire)
            {
                GameObject newBullet = Instantiate(bulletPrefab, pistolDirection.position + pistolDirection.forward + shift, pistolDirection.rotation);
                Rigidbody r = newBullet.GetComponent<Rigidbody>();
                r.velocity = (pistolDirection.forward) * bulletSpeed;
                bulletsInMagazine--;
                if (bulletsInMagazine <= 0)
                {
                    canFire = false;
                }
                uISingleton.setBullets(bulletsInMagazine.ToString());
            }
        }
        if (Input.GetKeyDown("r"))
        {
            if(magazines > 0){
                canFire = false;
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        uISingleton.setBullets("reloading");
        yield return new WaitForSeconds(2);
        bulletsInMagazine = 10;
        magazines --;
        uISingleton.setBullets(bulletsInMagazine.ToString());
        uISingleton.setMagazines(magazines.ToString());
        canFire = true;
    }

    public int AddMagazine(){
            this.magazines++;
            return this.magazines;
    }
}
