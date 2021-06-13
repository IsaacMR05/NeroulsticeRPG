using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangeAttack : StateMachineBehaviour
{

    FireBullets fire;
    Boss boss; //Make him invencible
    public int fireCase;
    public int totalBullets;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        animator.SetBool("RangeAttack", true);
        fire = animator.GetComponent<FireBullets>();
        fire.fireCase = fireCase;
        if(fireCase == 1)
        {
            fire.bulletsAmount = totalBullets;
        }
        else
        {
            fire.bulletsAmount = 1;
        }
        //fire.startShooting = true;
        boss.EnableFire();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //fire.startShooting = true;
        //fire.fireCase = 0;
        //fire.StopInvoking();
        boss.DisableFire();
    }


}
