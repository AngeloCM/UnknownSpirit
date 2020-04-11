using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Pistol;

    [SerializeField]
    public GameObject MachineGun;

    [SerializeField]
    public GameObject ShotGun;

    [SerializeField]
    float timeToSpawn = 10f;

    GameObject[] allSpawners;

    public void Awake()
    {
        allSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn < 0)
        {
            SpawnGun();
            timeToSpawn = 8f;
        }
    }

    GameObject RandomGun()
    {
        int gun = Random.Range(1, 3);

        if (gun == 1)
        {
            return Pistol;
        }
        else if (gun == 2)
        {
            return MachineGun;
        }
        else
        {
            return ShotGun;
        }
    }

    void SpawnGun()
    {
        GameObject gunToSpawn = RandomGun();

        Instantiate(gunToSpawn, allSpawners[Random.Range(0, allSpawners.Length)].transform.position, Quaternion.identity);
    }
}
