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

    public Text HighScore;
    public Text timer;
    public Text Health;
    public Text Ammo;
    public Text First;
    public Text Second;
    public Text Third;
    public Text YourTime;
    public Texture2D cursorShot;

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
        Ammo.color = Color.red;

        Cursor.SetCursor(cursorShot, Vector2.zero, CursorMode.ForceSoftware);

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
            ShowHighScore("High Scores", Color.yellow);
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

    private void ShowHighScore(string text, Color color)
    {
        HighScore.gameObject.SetActive(true);
        HighScore.text = text;
        HighScore.color = color;
    }

    private void SetButton()
    {
        Restart.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
    }

    private void UpdateTime()
    {
        timer.text = "Timer : " + (int)time + "s";
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
        YourTime.color = Color.green;

        int LastElement = scores.HighScores.Count;

        First.text = "First Place: " + scores.HighScores.ElementAt(LastElement - 1).ToString("n2") + "s";
        First.gameObject.SetActive(true);

        Second.text = "Second Place: " + scores.HighScores.ElementAt(LastElement - 2).ToString("n2") + "s";
        Second.gameObject.SetActive(true);

        Third.text = "Third Place: " + scores.HighScores.ElementAt(LastElement - 3).ToString("n2") + "s";
        Third.gameObject.SetActive(true);

        YourTime.text = "Your Time: " + (int)time + "s";
        YourTime.gameObject.SetActive(true);
    }
}
