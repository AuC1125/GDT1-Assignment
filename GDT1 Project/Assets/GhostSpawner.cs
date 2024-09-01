using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Spawner;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    
    private float GhoulSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        GhoulSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        GhoulSpawn -= Time.deltaTime;

        if(GhoulSpawn <= 0)
        {
            Instantiate(Spawner, transform.position, Quaternion.identity);
            GhoulSpawner();
        }
    }

    void GhoulSpawner()
    {
        GhoulSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
