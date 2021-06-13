using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Transform player;
    public Attribute attributes; 
    public  new string name;
    public   int experience;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null && name != "Box")
        {
            if (player.transform.position.y > this.transform.position.y)
            {
                sprite.sortingOrder = 2;
            }
            else
            {
                sprite.sortingOrder = 0;
            }
        }
    }
}
