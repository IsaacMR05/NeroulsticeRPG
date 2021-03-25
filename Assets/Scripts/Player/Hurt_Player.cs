using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurt_Player : MonoBehaviour
{
    private Health_Manager healthMan;
    public float wait_to_hurt = 2f;
    private bool isTouching;
    [SerializeField]
    private int damageToGive = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<Health_Manager>(); //explicar 
    }

    // Update is called once per frame
    void Update()
    {
       /* if (reloading)// es un contador de dos segundos para que tardes 2 segundos en volver a cargar la escena.
        {
            wait_to_load_the_scene -= Time.deltaTime;
            if(wait_to_load_the_scene <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //hemos añadido nuevo include para esto, la siguiente funcion,
                                                                            //mira el nombre de la scene activada y nos reprintea en ella, para no ir repitiendo y poniendo nombres de scene.
            }
        }*/

        if (isTouching)//Necesito explicar( tornar a mirar el video)
        {
            wait_to_hurt -= Time.deltaTime;
            if (wait_to_hurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                wait_to_hurt = 2f;
            }
            /*
            else if (healthMan.currentHealth <= 0)
            {
                
            }

            */

        }



    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       if ( other.collider.tag == "Player")
        {
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);    //eso hace que se quite el tick de arriba y lo hace invisible

            other.gameObject.GetComponent<Health_Manager>().HurtPlayer(damageToGive);


            //reloading = true;
            //hará que se active el if de arriba

        }
    }
    private void OnCollisionStay2D(Collision2D collision) // necesito explicarlo( tornar a mirar el video
    {
        isTouching = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouching = false;
    }
}
