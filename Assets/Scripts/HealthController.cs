using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float health;

    [SerializeField]
    private float healthLoseOnCollision;

    [SerializeField]
    private PistolScript pistol;

    UISingleton uISingleton;

    void Start()
    {
        uISingleton = UISingleton.Instance;
        uISingleton.setHealth(health);
    }

    void Update()
    {
        if(health <= 0.0f)
        {
            uISingleton.showGameOver();
        }
    }

    private void OnCollsionWithEnemy(Collision collision)
    {
            health = health - healthLoseOnCollision;
            uISingleton.setHealth(health);
    }

    private void OnCollsionWithAmmo(Collision collision)
    {
        uISingleton.setMagazines(pistol.AddMagazine().ToString());
        Destroy(collision.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && health > 0)
        {
            OnCollsionWithEnemy(collision);
        }
        if (collision.gameObject.tag == "Ammo")
        {
            OnCollsionWithAmmo(collision);
        }
    }

   

    void OnCollisionStay(Collision collision)
    {
        OnCollisionEnter(collision);
    }


   
}
