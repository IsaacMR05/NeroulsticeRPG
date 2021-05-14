using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Level level;
    private Health_Manager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        level = new Level(1, leveledUp);
        playerHealth = GetComponent<Health_Manager>();
    }

    private void leveledUp()
    {
            playerHealth.currentHealth += playerHealth.healYouself; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            level.AddExp(100);
        }
    }
}
