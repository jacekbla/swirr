using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCircle : MonoBehaviour
{
    // Instantiates prefabs in a circle formation
   public GameObject[] prefabs;
   public int numberOfObjects = 20;
   public float radius = 5f;

   public bool hasEnemyController = false;
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

            GameObject prefab = GetPrefab();
            if(prefab){
                GameObject newMob = (GameObject)Instantiate(prefab, pos, rot);
                if(hasEnemyController){
                    EnemyController enemyController = newMob.GetComponent<EnemyController>();
                    enemyController.target = GameObject.Find("OVRPlayerController").transform;
                }
            }
        }
    }

    GameObject GetPrefab(){

        if(prefabs.Length > 0) {
            return prefabs[Random.Range(0,prefabs.Length)];
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
