using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health_Manager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int healYouself = 0;
    public int lifes = 3;


    private bool flashActive;
    [SerializeField]//per poder-ho cambiar desde Unity
    private float flashLength = 1f;
    private float flashCounter = 0f; //temps que voldrem parpallejar a la pantalla

    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        lifes = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth; 
        }

        if (flashActive)
        {
            /*for (float i = 0f; i < flashLength; i += Time.deltaTime)
            {
                if (i % 2 == 0)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);
                }
                else
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
                }
            }
            */
                
            if(flashCounter > flashLength * 0.99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);
                // el k fem es asegurar-nos que no parpadee, mirem tots el canals de colors R,G,B i A (alpha), cambiem l'últim canal pk desaparegui.
            }
            else if (flashCounter > flashLength * 0.82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
            }
            else if (flashCounter > flashLength * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);
            }
            else if (flashCounter > flashLength * 0.5f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
            }
            else if (flashCounter > flashLength * 0.34f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);
            }
            else if (flashCounter > flashLength * 0.18f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
            }
            else if (flashCounter > flashLength * 0.02f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);
            }


            if (flashCounter <= 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
                // el k fem es asegurar-nos que no parpadee, mirem tots el canals de colors R,G,B i A (alpha).

                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
            
        }
    }
    public void HurtPlayer(int damageToGive) // funcion que baja la vida al player
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        if(currentHealth <= 0)
        {
            lifes--;
            if(lifes <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
            
        }
    }
}
