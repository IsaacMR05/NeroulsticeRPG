using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

    public GameObject popUp;

    void Start()
    {
        popUp.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Weapon") || other.CompareTag("NPC"))
        {
            popUp.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Weapon") || other.CompareTag("NPC"))
        {
            popUp.SetActive(false);
        }
    }


}
