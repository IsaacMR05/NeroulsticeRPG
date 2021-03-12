using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Respawn d'enemics aleatori


public class MasterScript : MonoBehaviour
{
    public int numberOfEnemies = 0;
    public GameObject enemies = null;
    public int halfWidth = 0;
    public int halfHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(enemies != null)
        {
            for(int i =0; i < numberOfEnemies; i++)
            {
                Vector2 enemiesPosition = new Vector2(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight));

                GameObject.Instantiate(enemies, enemiesPosition, new Quaternion());
            
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
