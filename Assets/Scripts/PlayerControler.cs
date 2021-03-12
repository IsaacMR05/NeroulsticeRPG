using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    //Public 
   [SerializeField] private float velocity = 3;  // unidades de coordenadas globales por segundo m/s m= 3 s= deltaTime,
                                                 // no serà manipoulada por otras clasese, pero la podremos editar desde el inspector

    //Private
    private InputPlayer inputJugador;
    private Transform transformada;
   
    private float horizontal;
    private float vertical;


    // Start is called before the first frame update
    void Start() {
        inputJugador = GetComponent<InputPlayer>();   //Buscara dentro de game object, mi player, una variable tipo inputPlayer
        transformada = GetComponent<Transform>(); // transformara el valor de la variable que queramos en el valor que queramos


    }

    // Update is called once per frame
    void Update()
    {
        //variables de los ejes
        horizontal = inputJugador.horizontalAxis;
        vertical = inputJugador.verticalAxis;


        //Moveremos modificando la transformada
        //Vector2 y Vector3 son structs!!!!
        Vector2 newPosition = transformada.position + new Vector3(velocity * horizontal*Time.deltaTime, velocity * vertical*Time.deltaTime, 0);//Quitar el frame rate
        transformada.position = newPosition;
        Debug.Log("Atacando usando player controller"+inputJugador.attack);
    }
}
