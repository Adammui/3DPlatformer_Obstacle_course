using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ObjectSpawn", spawnTime, spawnDelay);
    }

    // Should destroy object when it is colliding with start platform. Currently nis now working
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Start")
        {
            ObjectDestroy();
        }
    }

    //Destroys object to which this script is assigned
    void ObjectDestroy()
    {
        Destroy(this.gameObject);
    }

    //Spawns new object in position where current object with this script is located
    public void ObjectSpawn()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
    }
}
