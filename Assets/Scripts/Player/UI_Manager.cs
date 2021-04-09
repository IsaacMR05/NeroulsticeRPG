using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //llibreria per usar funcions de UI

public class UI_Manager : MonoBehaviour
{
    private Health_Manager healthMan;
    public Slider healthBar;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<Health_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        hpText.text = healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
