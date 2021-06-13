using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlimes : StateMachineBehaviour
{

    public GameObject slime;
    float randX;
    float randY;
    public int enemiesSpawn;
    Vector2 spawnPoint;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for(int i = 0; i < enemiesSpawn; i++)
        {
            randX = Random.Range(-52.39f, -34.42f);
            randY = Random.Range(9.52f, 20.97f);
            spawnPoint = new Vector2(randX, randY);
            Instantiate(slime, spawnPoint, Quaternion.identity);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
