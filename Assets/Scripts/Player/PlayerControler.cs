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
    public float speed = 1f;  // unidades de coordenadas globales por segundo m/s m= 3 s= deltaTime,
    public Vector2 direction;                            // no serà manipoulada por otras clasese, pero la podremos editar desde el inspector

   

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;

    //Private
    private InputPlayer inputJugador;
    //private Transform transformada;
    private Animator myAnimator;

    private float horizontal;
    private float vertical;

    //Attack
    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool attacking;


    // Start is called before the first frame update
    void Start()
    {
        inputJugador = GetComponent<InputPlayer>();   //Buscara dentro de game object, mi player, una variable tipo inputPlayer
        //transformada = GetComponent<Transform>(); // transformara el valor de la variable que queramos en el valor que queramos
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //variables de los ejes

        horizontal = inputJugador.horizontalAxis;
        vertical = inputJugador.verticalAxis;

        direction = new Vector2(horizontal, vertical);




        //Moveremos modificando la transformada
        //Vector2 y Vector3 son structs!!!!

        // Vector2 newPosition = transformada.position + new Vector3(speed * horizontal*Time.deltaTime, speed * vertical*Time.deltaTime, 0);//Quitar el frame rate
        // transformada.position = newPosition;

        rb.velocity = new Vector2(horizontal, vertical)*speed * Time.deltaTime;


        myAnimator.SetFloat("moveX", rb.velocity.x);
        myAnimator.SetFloat("moveY", rb.velocity.y);

        if (horizontal == 1 || horizontal == -1|| vertical == 1 || vertical == -1)
        {
            myAnimator.SetFloat("lastMoveX", horizontal);
            myAnimator.SetFloat("lastMoveY", vertical);
        }


        Debug.Log("Atacando usando player controller" + inputJugador.attack);
        Debug.Log("velocity:" + speed);


        if (attacking)
        {
            //Si volem fer que pari de moure's quan ataqui
            rb.velocity = Vector2.zero;


            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                myAnimator.SetBool("attacking", false);
                attacking = false;
            }
        }



        if (Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            myAnimator.SetBool("attacking", true);
            attacking = true;
        }

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


