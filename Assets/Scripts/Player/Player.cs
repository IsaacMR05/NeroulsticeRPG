using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Level level;
    private Health_Manager playerHealth;
    public ParticleSystem onLevelUp;

    // Start is called before the first frame update
    void Start()
    {
        level = new Level(1, leveledUp);
        playerHealth = GetComponent<Health_Manager>();
    }

    private void leveledUp()
    {
        LevelUpAnimation();
        playerHealth.currentHealth += playerHealth.healYouself; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelUpAnimation()
    {
        onLevelUp.Play();
    }
}
