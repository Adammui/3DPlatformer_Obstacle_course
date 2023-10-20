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
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Start")
        {
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
    }
}
