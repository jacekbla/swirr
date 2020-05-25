using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public Transform pistolDirection;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;

    private Vector3 shift = new Vector3(0, 0.2f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            GameObject newBullet = Instantiate(bulletPrefab, pistolDirection.position+pistolDirection.forward+shift, pistolDirection.rotation);
            Rigidbody r = newBullet.GetComponent<Rigidbody>();
            r.velocity = (pistolDirection.forward) * bulletSpeed;
        }
    }
}
