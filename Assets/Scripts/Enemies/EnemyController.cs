using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Wandering wandering;
    private EnemyAI ai;

    public float attackDistance;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        wandering = GetComponent<Wandering>();
        ai = GetComponent<EnemyAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        wandering.enabled = true;
        ai.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < attackDistance) 
        {
            wandering.enabled = false;
            ai.enabled = true;
        }
        else
        {
            wandering.enabled = true;
            ai.enabled = false;
        }
    }
}
