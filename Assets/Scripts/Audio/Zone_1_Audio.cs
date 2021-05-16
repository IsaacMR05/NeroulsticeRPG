using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_1_Audio : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == Game_Manager.Instance.PC.gameObject)
            AudioManager.instance.PlayBGM(5);
    }
}
