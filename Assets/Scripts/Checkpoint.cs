using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public Health_Manager health;
    public GameObject firstSpawn;
    public GameObject player;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (health.lifes <= 0 && health != null && firstSpawn != null)
        {

            gm.lastCheckPointPos = firstSpawn.transform.position;
        }
        else if (health.currentHealth <= 0)
        {
            health.currentHealth = health.maxHealth;
            player.transform.position = gm.lastCheckPointPos;

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            gm.lastCheckPointPos = transform.position;
        }

    }
}
