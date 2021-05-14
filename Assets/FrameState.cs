using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameState : MonoBehaviour
{
    public Image frame;
    public Sprite above75;
    public Sprite above50;
    public Sprite above25;
    public Sprite above0;
    public Sprite dead;
    public Health_Manager player;


    void Start()
    {
        frame = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {

        if (player.currentHealth > player.maxHealth*0.75)
        {
            frame.sprite = above75;
        }
        else if (player.currentHealth > player.maxHealth * 0.50) 
        {
            frame.sprite = above50;
        }
        else if (player.currentHealth > player.maxHealth * 0.25)
        {
            frame.sprite = above25;
        }
        else if (player.currentHealth > 0)
        {
            frame.sprite = above0;
        }
        else
        {
            frame.sprite = dead;
        }
    }
}
