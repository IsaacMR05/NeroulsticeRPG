using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Wandering wandering;
    private EnemyAI ai;
    //private AlternativeEnemyAI alternativeAi;

    public float attackDistance;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        wandering = GetComponent<Wandering>();
        ai = GetComponent<EnemyAI>();
        //alternativeAi = GetComponent<AlternativeEnemyAI>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (wandering != null)
            wandering.enabled = true;

        if (ai != null)
            ai.enabled = false;

        /*if (alternativeAi != null)
            alternativeAi.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Vector2.Distance(transform.position, player.position));

        if (Vector2.Distance(transform.position, player.position) < attackDistance) 
        {
            if(wandering != null)
            wandering.enabled = false;

            if (ai != null)
                ai.enabled = true;

            /*if (alternativeAi != null)
                alternativeAi.enabled = true;*/
        }
        else
        {
            if (wandering != null)
                wandering.enabled = true;

            if (ai != null)
                ai.enabled = false;

            /*if (alternativeAi != null)
                alternativeAi.enabled = false;*/

        }
    }
}
