using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour { 

// Usamos un atributo para decirlo a Unity como ha de tratar la variable,HideInInspector, hace que ya no la veamos en Unity
   [HideInInspector] public float horizontalAxis; 
   [HideInInspector] public float verticalAxis;
   [HideInInspector] public bool attack;
   [HideInInspector] public bool spell;
   [HideInInspector] public bool inventory;
   [HideInInspector] public bool interact;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //atacar = Input.GetKeyDown(KeyCode.A);//no recomendada
        attack = Input.GetButtonDown("Atacar");
        spell = Input.GetButtonDown("Spell");
        //inventory = Input.GetButtonDown("Invent");
        interact = Input.GetButtonDown("Interact");

        //Definir ejes de movimiento
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");
        //Debug.Log("El eje horizontal es "+ horizontalAxis + "el eje vertical es "+ verticalAxis);
    }
}
