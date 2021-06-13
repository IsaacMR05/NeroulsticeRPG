using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    EnemyHealthManager bossHealth;
    public float speed = 2.5f;
    public float onRangeDistance = 4.0f;
    public float waitForRangeAttck = 0;
    public float rangeAttckRate = 10;

 
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossHealth = animator.GetComponent<EnemyHealthManager>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Time.time > waitForRangeAttck)
        {
            waitForRangeAttck = Time.time + rangeAttckRate;
            animator.SetTrigger("Invoke!");
        }
        
        Vector2 target = new Vector2(player.position.x , player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        //Check the boss life and change the phase if its necessary
        if (bossHealth.currentHealth < bossHealth.maxHealth * 0.25)
        {
            animator.SetTrigger("Phase 3");
        }
        else if (bossHealth.currentHealth < bossHealth.maxHealth * 0.5)
        {
            animator.SetTrigger("Phase 2");
        }
        else if (bossHealth.currentHealth < bossHealth.maxHealth * 0.75)
        {
            animator.SetTrigger("Phase 1");
            //bossSprite.color = new Color(255, 121, 142);
        }
        else if (bossHealth.currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
        }

        if (Vector2.Distance(player.position, rb.position) <= onRangeDistance)
        {
            animator.SetTrigger("Attack");
        }

        animator.SetFloat("movX", newPos.x);
        animator.SetFloat("movY", newPos.y);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Invoke!");
    }
}
