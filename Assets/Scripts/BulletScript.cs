using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollsionWithEnemy(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Terrain")
        {
            Destroy(this.gameObject);
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
