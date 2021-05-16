using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private int damageToGive;
    private float percentage = 1;
    private int wrenchBaseDamage = 4;
    private int knifeBaseDamage = 5;
    private int swordBaseDamage = 12;
    public bool isCritic = false;

    private Game_Manager weapon;
    public int weaponID;

    //Damage Number

    public DamageNumber theDamageNumber;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Game_Manager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        weaponID = weapon.weaponID;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Random.Range(0,100) <= 10){
            isCritic = true;
        }
        if (isCritic)
        {
            percentage = 1.5f;
            isCritic = false; 
        }
        else
        {
            percentage = 1;
        }
        switch (weaponID)
        {
            case 0:
                if (other.tag == "Enemy") //només te el tag el slime
                {

                    damageToGive = (int)((knifeBaseDamage + Random.Range(0,3))*percentage);
                    EnemyHealthManager eHealth;
                    eHealth = other.gameObject.GetComponent<EnemyHealthManager>();
                    eHealth.HurtEnemy(damageToGive);
                   // Instantiate(theDamageNumber, other.GetComponent<Transform>().position, other.GetComponent<Transform>().rotation).SetDamage(damageToGive);
                }
                break;

            case 1:
                
                if (other.tag == "Enemy") //només te el tag el slime
                {
                    damageToGive = (int)((wrenchBaseDamage + Random.Range(0, 1))*percentage); 
                    EnemyHealthManager eHealth;
                    eHealth = other.gameObject.GetComponent<EnemyHealthManager>();
                    eHealth.HurtEnemy(damageToGive);
                }
                break;

            case 2:
                if (other.tag == "Enemy") //només te el tag el slime
                {
                    damageToGive = (int)((swordBaseDamage + Random.Range(0,3))*percentage);
                    EnemyHealthManager eHealth;
                    eHealth = other.gameObject.GetComponent<EnemyHealthManager>();
                    eHealth.HurtEnemy(damageToGive);
                }
                break;

            default: break;



        }

    }
}
