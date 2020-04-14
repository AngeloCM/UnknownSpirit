using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyPrefeb;

    [SerializeField]
    public float Timer = 300f;

    [SerializeField]
    public float timeToSpawn = 5f;

    GameObject[] allSpawners;

    public void Awake()
    {
        allSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        Timer -= Time.deltaTime;

        if (Timer > 0f)
        {
            if (timeToSpawn < 0)
            {
                SpawnEnemy();
                timeToSpawn = 8f;
            }
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefeb, allSpawners[Random.Range(0, allSpawners.Length)].transform.position, Quaternion.identity);
    }
}
