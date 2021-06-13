using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;

    public bool looksPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //gameObject.SetActive(false);
    }

   
    public void Dead()
    {
        Destroy(this.gameObject);
    }

}
