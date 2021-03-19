using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    //Public 
    [Header("Horizontal Movement")]
    public float speed = 1f;  // unidades de coordenadas globales por segundo m/s m= 3 s= deltaTime,
    public Vector2 direction;                            // no serà manipoulada por otras clasese, pero la podremos editar desde el inspector

    // [Header("Horizontal Movement")]
    //public Vector2 direction_Y;

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;

    //Private
    private InputPlayer inputJugador;
    private Transform transformada;

    private float horizontal;
    private float vertical;


    // Start is called before the first frame update
    void Start()
    {
        inputJugador = GetComponent<InputPlayer>();   //Buscara dentro de game object, mi player, una variable tipo inputPlayer
        transformada = GetComponent<Transform>(); // transformara el valor de la variable que queramos en el valor que queramos
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

        Vector2 newPosition = transformada.position + new Vector3(speed * horizontal*Time.deltaTime, speed * vertical*Time.deltaTime, 0);//Quitar el frame rate
        transformada.position = newPosition;
        Debug.Log("Atacando usando player controller" + inputJugador.attack);
        Debug.Log("velocity:" + speed);

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


