﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Inventory part:
    public Transform hand;
    public Transform body;

    //Public 
    [Header("Horizontal Movement")]
    public float speed = 1f;  // unidades de coordenadas globales por segundo m/s m= 3 s= deltaTime,
    public Vector2 direction; // no serà manipoulada por otras clasese, pero la podremos editar desde el inspector

   

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;

    //Private
    private InputPlayer inputJugador;
    //private Transform transformada;
    private Animator myAnimator;

    private Game_Manager weapon;

    private float horizontal;
    private float vertical;
    private float horizontalRaw;
    private float verticalRaw;
    public int weaponID;

    //Attack
    private float attackTime = 0.44f;
    private float attackCounter = 1.0f;
    private bool swordAttacking;
    private bool scalpelAttacking;


    // Start is called before the first frame update
    void Start()
    {
        inputJugador = GetComponent<InputPlayer>();   //Buscara dentro de game object, mi player, una variable tipo inputPlayer
        //transformada = GetComponent<Transform>(); // transformara el valor de la variable que queramos en el valor que queramos
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        weapon = FindObjectOfType<Game_Manager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontal = inputJugador.horizontalAxis;
        vertical = inputJugador.verticalAxis;
        horizontalRaw = inputJugador.horizontalAxisRaw;
        verticalRaw = inputJugador.verticalAxisRaw;
    
        direction = new Vector2(horizontal, vertical);
        weaponID = weapon.weaponID;
        
    }

    void Update()
    {
       
        
        rb.velocity = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        if (!swordAttacking && !scalpelAttacking) 
        { 
            myAnimator.SetFloat("moveX", (int)rb.velocity.x);
            myAnimator.SetFloat("moveY", (int)rb.velocity.y);


            if (horizontalRaw >= 1.0f || horizontalRaw <= -1.0f || verticalRaw >= 1.0f || verticalRaw <= -1.0f) 
            { 
                myAnimator.SetFloat("lastMoveX", horizontalRaw);  
                myAnimator.SetFloat("lastMoveY", verticalRaw);
            }
        }
        
        switch (weaponID)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.T) && !scalpelAttacking)
                {
                        attackCounter = attackTime;
                        myAnimator.SetBool("scalpelAttacking", true);
                        scalpelAttacking = true;
                }

                if (scalpelAttacking)
                {
                    //Si volem fer que pari de moure's quan ataqui
                    rb.velocity = Vector2.zero;


                    attackCounter -= Time.deltaTime;
                    if (attackCounter <= 0)
                    {
                        myAnimator.SetBool("scalpelAttacking", false);
                        scalpelAttacking = false;
                    }

                    

                }
                break;

            case 1:      
                if (Input.GetKeyDown(KeyCode.T) && !swordAttacking)
                {
                        attackCounter = attackTime;
                        myAnimator.SetBool("swordAttacking", true);
                        swordAttacking = true;
                }

                if (swordAttacking)
                {
                    //Si volem fer que pari de moure's quan ataqui
                    rb.velocity = Vector2.zero;


                    attackCounter -= Time.deltaTime;
                    if (attackCounter <= 0)
                    {
                        myAnimator.SetBool("swordAttacking", false);
                        swordAttacking = false;
                    }

              
                }

                break;

            default: break;
        }
     /*
        
        if (attacking)
        {
            //Si volem fer que pari de moure's quan ataqui
            rb.velocity = Vector2.zero;


            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnimator.SetBool("swordAttacking", false);
                attacking = false;
            }
        }
   


        if (Input.GetKeyDown(KeyCode.T) && !attacking)
        {
            attackCounter = attackTime;
            myAnimator.SetBool("attacking", true);
            attacking = true;
        }
        */
    }


}






    /*
    void FixedUpdate()
    {
        moveCharacter(direction.x, direction.y);
       // modifyPhysics();
        

    }
    void moveCharacter(float horizontal, float vertical)
    {
        rb.AddForce(Vector2.right * horizontal * speed);

        rb.AddForce(Vector2.up * vertical * speed);
        
        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed,rb.velocity.y);
        }
        
        
        else if (Mathf.Abs(rb.velocity.y) > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x , Mathf.Sign(rb.velocity.y) * maxSpeed);
        }
        

    }

}
    */


