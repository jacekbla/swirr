using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCircle : MonoBehaviour
{
    // Instantiates prefabs in a circle formation
   public GameObject prefab;
   public int numberOfObjects = 20;
   public float radius = 5f;
   void Start()
   {
        InvokeRepeating("SpawnMobs", 0, 60);
   }

    void SpawnMobs()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 10, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);

            GameObject newMob = (GameObject)Instantiate(prefab, pos, rot);
            EnemyController enemyController = newMob.GetComponent<EnemyController>();
            enemyController.target = GameObject.Find("OVRPlayerController").transform;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
