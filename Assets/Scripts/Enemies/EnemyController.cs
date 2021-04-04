using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Wandering wandering;
    private EnemyAI ai;
    private AlternativeEnemyAI alternativeAi;

    public float attackDistance;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        wandering = GetComponent<Wandering>();
        ai = GetComponent<EnemyAI>();
        alternativeAi = GetComponent<AlternativeEnemyAI>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        wandering.enabled = true;
        ai.enabled = false;
        alternativeAi.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < attackDistance) 
        {
            wandering.enabled = false;
            ai.enabled = true;
            alternativeAi.enabled = true;
        }
        else
        {
            wandering.enabled = true;
            ai.enabled = false;
            alternativeAi.enabled = false;

        }
    }
}
