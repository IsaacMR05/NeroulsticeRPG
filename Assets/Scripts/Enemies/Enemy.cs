using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attribute attributes; 
    public  new string name;
    public   int experience;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }

}
