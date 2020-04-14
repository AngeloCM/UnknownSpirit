using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    GameObject SpawnerReference;

    public Text timer;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.FindGameObjectWithTag("Spawn").GetComponent<EnemySpawner>().Timer;

        timer.text = "Timer";
        timer.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        UpdateTime();
    }

    private void UpdateTime()
    {
        timer.text = "Timer : " + (int)time;
    }
}
