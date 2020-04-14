using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int Health = 5;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Destroy(this.gameObject);
        isDead = true;
    }
}
