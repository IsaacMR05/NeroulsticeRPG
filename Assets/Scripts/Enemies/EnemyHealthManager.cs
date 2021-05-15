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
    

    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    

    public void HurtEnemy (int damageToGive)
    {
        currentHealth -= damageToGive;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
           playerLevel.level.AddExp(enemy.experience); //Call function to give XP for the player
           Destroy(gameObject);
        }
    }
}
