using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float health;

    [SerializeField]
    private float healthLoseOnCollision;

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
        if (collision.gameObject.tag == "Enemy" && health > 0)
        {
            health = health - healthLoseOnCollision;
            uISingleton.setHealth(health);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        OnCollsionWithEnemy(collision);
    }


    void OnCollisionStay(Collision collision)
    {
        OnCollsionWithEnemy(collision);
    }


   
}
