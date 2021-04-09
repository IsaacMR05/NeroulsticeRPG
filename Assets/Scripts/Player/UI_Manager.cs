using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //llibreria per usar funcions de UI

public class UI_Manager : MonoBehaviour
{
    private Health_Manager healthMan;
    public Slider healthBar;
    public Text hpText;

    public Player player;

    private Level levelMan;
    public Slider expBar;
    public Text expText;
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


        expBar.maxValue = player.level.GetXPForLevel(player.level.currentLevel + 1) - player.level.GetXPForLevel(player.level.currentLevel);
        expBar.value = player.level.experience - player.level.GetXPForLevel(player.level.currentLevel);
        expText.text = "Lvl: "+ player.level.currentLevel;

        // (experience - GetXPForLevel(currentLevel)) / (GetXPForLevel(currentLevel + 1) - GetXPForLevel(currentLevel)

    }
}
