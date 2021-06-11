using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControler : MonoBehaviour
{
    //Inventory part:
    public Transform hand;
    public Transform body;

    //Public 
    [Header("Horizontal Movement")]
    
    public float speed;  // unidades de coordenadas globales por segundo m/s m= 3 s= deltaTime,
    public float sprintingSpeed;
    public float walkingSpeed;
    public Vector2 direction; // no serà manipoulada por otras clasese, pero la podremos editar desde el inspector
    public bool isSprinting;
   

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
    private bool scalpelAttacking;
    private bool wrenchAttacking;
    private bool swordAttacking;

    //Particles
    public GameObject particle;
    

    public bool canMove = true;

    public static PlayerControler instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        inputJugador = GetComponent<InputPlayer>();   //Buscara dentro de game object, mi player, una variable tipo inputPlayer
        //transformada = GetComponent<Transform>(); // transformara el valor de la variable que queramos en el valor que queramos
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        weapon = FindObjectOfType<Game_Manager>();
        particle.SetActive(false);
        
        myAnimator.SetFloat("lastMoveY", -0.1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
     
        
    }

    void Update()
    {
        horizontal = inputJugador.horizontalAxis;
        vertical = inputJugador.verticalAxis;
        horizontalRaw = inputJugador.horizontalAxisRaw;
        verticalRaw = inputJugador.verticalAxisRaw;

        direction = new Vector2(horizontal, vertical);
        weaponID = weapon.weaponID;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting)
        {
            particle.SetActive(true);
            speed = sprintingSpeed;
        }
        else
        {
            particle.SetActive(false);
            speed = walkingSpeed;
        }

        if (canMove)
        {
            rb.velocity = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (canMove)
        {
            if (!swordAttacking && !scalpelAttacking && !wrenchAttacking)
            {
                myAnimator.SetFloat("moveX", (int)rb.velocity.x);
                myAnimator.SetFloat("moveY", (int)rb.velocity.y);



                //if (horizontalRaw >= 1.0f || horizontalRaw <= -1.0f || verticalRaw >= 1.0f || verticalRaw <= -1.0f)
                //{
                //    myAnimator.SetFloat("lastMoveX", horizontalRaw);
                //    myAnimator.SetFloat("lastMoveY", verticalRaw);
                //}
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    myAnimator.SetFloat("lastMoveX", -1f);
                    myAnimator.SetFloat("lastMoveY", 0);
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    myAnimator.SetFloat("lastMoveX", 1f);
                    myAnimator.SetFloat("lastMoveY", 0);
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    myAnimator.SetFloat("lastMoveX", 0);
                    myAnimator.SetFloat("lastMoveY", 1f);
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    myAnimator.SetFloat("lastMoveX", 0);
                    myAnimator.SetFloat("lastMoveY", -1f);
                }

            }
        }
        
        
        switch (weaponID)
        {
            case 0:

                if (Input.GetKeyDown(KeyCode.LeftArrow) && !scalpelAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("scalpelAttacking", true);
                    scalpelAttacking = true;
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow) && !scalpelAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("scalpelAttacking", true);
                    scalpelAttacking = true;
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow) && !scalpelAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("scalpelAttacking", true);
                    scalpelAttacking = true;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow) && !scalpelAttacking)
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
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !wrenchAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("wrenchAttacking", true);
                    wrenchAttacking = true;
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow) && !wrenchAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("wrenchAttacking", true);
                    wrenchAttacking = true;
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow) && !wrenchAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("wrenchAttacking", true);
                    wrenchAttacking = true;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow) && !wrenchAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("wrenchAttacking", true);
                    wrenchAttacking = true;
                }

                if (wrenchAttacking)
                {
                    //Si volem fer que pari de moure's quan ataqui
                    rb.velocity = Vector2.zero;


                    attackCounter -= Time.deltaTime;
                    if (attackCounter <= 0)
                    {
                        myAnimator.SetBool("wrenchAttacking", false);
                        wrenchAttacking = false;
                    }

              
                }

                break;

            case 2:
                if ((Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))  && !swordAttacking)
                {
                    attackCounter = attackTime;
                    myAnimator.SetBool("swordAttacking", true);
                    swordAttacking = true;
                    //AudioManager.instance.PlaySFX(3);      i aixi faria sonar el so 
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


