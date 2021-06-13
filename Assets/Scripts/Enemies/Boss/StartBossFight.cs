using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{

    public GameObject boss;

    // Start is called before the first frame update


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
        }
            
    }

}
