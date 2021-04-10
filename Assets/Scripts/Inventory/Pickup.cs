using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int itemID;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == Game_Manager.Instance.PC.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Game_Manager.Instance.PickupItem(itemID);
                Destroy(gameObject);
            }
        }
    }
}