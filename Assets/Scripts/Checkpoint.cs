using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public Health_Manager health;
    public GameObject firstSpawn;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void Update()
    {
        if (health.lifes <= 0)
        {

            gm.lastCheckPointPos = firstSpawn.transform.position;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }

    }
}
