using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //per multiplicar la velocity
    public float velocity = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Rigidbody2D rb2 = GetComponent<Rigidbody2D>();

        //Controller + W,A,S,D
        rb2.velocity = new Vector2(Input.GetAxis("Horizontal")*velocity, rb2.velocity.y);
        rb2.velocity = new Vector2(rb2.velocity.x, Input.GetAxis("Vertical")*velocity);

        //Arrows
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2.AddForce(new Vector2(0, 2));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2.AddForce(new Vector2(0, -2));
        }*/

        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           rb2.AddForce(new Vector2(-2, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2.AddForce(new Vector2(2, 0));
        }
        */

    }
}
