using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float velocity = 3f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10,10)*velocity,Random.Range(-10,10)*velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
