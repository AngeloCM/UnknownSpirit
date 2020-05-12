using Assets.Scripts.Spawns;
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
    float timeToSpawn;

    float timer;

    GameObject[] arrayOfSpawners;

    public void Awake()
    {
        arrayOfSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    private void Start()
    {
        timer = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SpawnGun();
            timer = timeToSpawn;
        }
    }

    GameObject RandomGun()
    {
        int gun = Random.Range(1, 4);

        if (gun == 1)
        {
            return Pistol;
        }
        else if (gun == 2)
        {
            return MachineGun;
        }
        else if(gun == 3)
        {
            return ShotGun;
        }

        return null;
    }

    void SpawnGun()
    {
        GameObject gunToSpawn = RandomGun();
        int spawnPoint = Random.Range(0, arrayOfSpawners.Length);

        if (arrayOfSpawners[spawnPoint].GetComponent<Slot>().empty)
        {
            arrayOfSpawners[spawnPoint].GetComponent<Slot>().slotPowerUp = gunToSpawn;
            arrayOfSpawners[spawnPoint].GetComponent<Slot>().empty = false;
            arrayOfSpawners[spawnPoint].GetComponent<Slot>().slotPowerUp.GetComponent<PreFabSpawner>().SpawnerIndex = spawnPoint;
            Instantiate(gunToSpawn, arrayOfSpawners[spawnPoint].transform.position, Quaternion.identity);
            gunToSpawn.GetComponent<PreFabSpawner>().SpawnerIndex = spawnPoint;
        }
    }

    public void deletePowerUp(GameObject powerUp)
    {
        arrayOfSpawners[powerUp.GetComponent<PreFabSpawner>().SpawnerIndex].GetComponent<Slot>().slotPowerUp = null;
        arrayOfSpawners[powerUp.GetComponent<PreFabSpawner>().SpawnerIndex].GetComponent<Slot>().empty = true;
    }
}
