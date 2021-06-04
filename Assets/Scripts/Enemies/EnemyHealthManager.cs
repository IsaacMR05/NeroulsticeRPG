using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Player playerLevel;
    public Enemy enemy;
    private int playerExp;
    public HealthBar healthBar;
    private Animator myAnimator;




    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        currentHealth = maxHealth;
        if(healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }
    
    
    public void HurtEnemy (int damageToGive)
    {
        if (myAnimator != null)
        {
           myAnimator.SetBool("hit", true);
        }
        currentHealth -= damageToGive;
        if (healthBar != null)
        {
          healthBar.SetHealth(currentHealth);

        }

       

        if (currentHealth <= 0)
        {
            if (myAnimator != null)
            {
               myAnimator.SetBool("dead",true);
            }
            playerLevel.level.AddExp(enemy.experience); //Call function to give XP for the player
           if(myAnimator == null)
            {
                Destroy(gameObject);
            }
        }
    }



    public void StopHitAnimation()
    {
        if(myAnimator != null)
        {
            myAnimator.SetBool("hit", false);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
