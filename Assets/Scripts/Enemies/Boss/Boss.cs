using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;

    public bool looksPlayer;
    private FireBullets fire;

    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<FireBullets>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //gameObject.SetActive(false);
    }

   
    public void Dead()
    {
        Destroy(this.gameObject);
    }

    public void DisableFire()
    {
        fire.enabled = false;
    }

    public void EnableFire()
    {
        fire.enabled = true;
    }
}
