using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public GameObject SpawnerReference;
    public GameObject PlayerReference;

    public Text WinLose;
    public Text timer;
    public Text Health;
    public Button Restart;
    public Button Menu;

    float timeReference;
    int PlayerHealth;
    bool isPlayerDead;

    // Start is called before the first frame update
    void Start()
    {
        timeReference = SpawnerReference.GetComponent<EnemySpawner>().Timer;
        PlayerHealth = PlayerReference.GetComponent<Player>().Health;
        isPlayerDead = PlayerReference.GetComponent<Player>().isDead;


        timer.text = "Timer";
        timer.color = Color.yellow;

        Health.text = "Health";
        Health.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            SetButton();
            PlayerReference.GetComponent<PlayerController>().enabled = false;
            SetWinLoseState("You Lost", Color.red);
            
        }
        else if (timeReference < 0)
        {
            SetButton();
            PlayerReference.GetComponent<PlayerController>().enabled = false;
            SetWinLoseState("You Won", Color.green);
        }
        else
        {
            timeReference -= Time.deltaTime;
            UpdateTime();
            UpdateHealth();
            UpdatePlayerStatus();
        }
    }

    private void SetWinLoseState(string text, Color color)
    {
        WinLose.gameObject.SetActive(true);
        WinLose.text = text;
        WinLose.color = color;
    }

    private void SetButton()
    {
        Restart.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
    }

    private void UpdateTime()
    {
        timer.text = "Timer : " + (int)timeReference;
    }

    void UpdateHealth()
    {
        PlayerHealth = PlayerReference.GetComponent<Player>().Health;
        Health.text = "Health : " + PlayerHealth;
    }
    
    void UpdatePlayerStatus()
    {
        isPlayerDead = PlayerReference.GetComponent<Player>().isDead;
    }
}
