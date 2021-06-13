using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{

    public GameObject boss;
    private GameObject[] enemies;
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            Instantiate(boss, new Vector2(-43, 15), Quaternion.identity);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject newBoss = GameObject.FindGameObjectWithTag("Boss");
            Destroy(newBoss);

            enemies = GameObject.FindGameObjectsWithTag("Invoked");
            for(int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
        }
            
    }

}
