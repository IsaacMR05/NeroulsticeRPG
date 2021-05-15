﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public Health_Manager health;
    public bool healed = false;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<Health_Manager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!healed)
        {
            if (other.CompareTag("Player"))
            {
                health.currentHealth = health.maxHealth;
                healed = true;
            }
        }
        
    }
}
