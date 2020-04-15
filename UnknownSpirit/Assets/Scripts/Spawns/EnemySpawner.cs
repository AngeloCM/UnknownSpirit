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
    public float TimeToSpawn;

    GameObject[] allSpawners;

    float CountToSpawn;

    public void Awake()
    {
        allSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        CountToSpawn -= Time.deltaTime;
        Timer -= Time.deltaTime;

        if (Timer > 0f)
        {
            if (CountToSpawn < 0)
            {
                SpawnEnemy();
                CountToSpawn = TimeToSpawn;
            }
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefeb, allSpawners[Random.Range(0, allSpawners.Length)].transform.position, Quaternion.identity);
    }
}
