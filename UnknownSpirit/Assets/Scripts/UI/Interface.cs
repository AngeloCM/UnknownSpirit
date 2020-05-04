using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public GameObject SpawnerReference;
    public GameObject PlayerReference;

    public Text WinLose;
    public Text timer;
    public Text Health;
    public Text Ammo;
    public Text First;
    public Text Second;
    public Text Third;

    public Button Restart;
    public Button Menu;

    ScoreManager scores;

    float time;
    int PlayerHealth;
    int PlayerAmmo;
    string GunType;
    bool isPlayerDead;
    bool IsAdded;

    private void Awake()
    {
        scores = new ScoreManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = PlayerReference.GetComponent<Player>().Health;
        isPlayerDead = PlayerReference.GetComponent<Player>().isDead;


        timer.text = "Timer";
        timer.color = Color.yellow;

        Health.text = "Health";
        Health.color = Color.red;

        Ammo.text = "Ammo";
        Ammo.color = Color.blue;

        
        IsAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            SetButton();
            PlayerReference.GetComponent<PlayerController>().enabled = false;
            showHighScore();
            SetWinLoseState("High Scores", Color.yellow);
        }
        else
        {
            time += Time.deltaTime;
            UpdateTime();
            UpdateHealth();
            UpdatePlayerStatus();
            UpdateAmmo();
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
        timer.text = "Timer : " + (int)time;
    }

    void UpdateHealth()
    {
        PlayerHealth = PlayerReference.GetComponent<Player>().Health;
        Health.text = "Health : " + PlayerHealth;
    }

    void UpdateAmmo()
    {
        PlayerAmmo = PlayerReference.GetComponent<PlayerController>()._gunController._currentGun.amountOfBullets;
        GunType = PlayerReference.GetComponent<PlayerController>()._gunController._currentGun.GetType().Name;

        Ammo.text = $"{GunType} Ammo : " + PlayerAmmo;
    }

    void UpdatePlayerStatus()
    {
        isPlayerDead = PlayerReference.GetComponent<Player>().isDead;
    }

    void showHighScore()
    {
        if (!IsAdded)
        {
            scores.AddScoreToList(time);
            IsAdded = true;
        }

        First.color = Color.yellow;
        Second.color = Color.yellow;
        Third.color = Color.yellow;

        int LastElement = scores.HighScores.Count;

        


        First.text = "First Place: " + scores.HighScores.ElementAt(LastElement - 1);
        First.gameObject.SetActive(true);

        Second.text = "Second Place: " + scores.HighScores.ElementAt(LastElement - 2);
        Second.gameObject.SetActive(true);

        Third.text = "Third Place: " + scores.HighScores.ElementAt(LastElement - 3);
        Third.gameObject.SetActive(true);
    }
}
