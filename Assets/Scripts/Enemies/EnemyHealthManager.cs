using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Player playerLevel;
    public Enemy enemy;
    private int playerExp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HurtEnemy (int damageToGive)
    {
        currentHealth -= damageToGive;
        if(currentHealth <= 0)
        {
           playerLevel.level.AddExp(enemy.experience); //Call function to give XP for the player
           Destroy(gameObject);
        }
    }
}
