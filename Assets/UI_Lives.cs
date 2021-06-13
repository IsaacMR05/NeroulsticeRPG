using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lives : MonoBehaviour
{
    public Image myImage;
    public Sprite threeLives;
    public Sprite twoLives;
    public Sprite oneLive;

    public Health_Manager player;


    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        myImage.sprite = threeLives;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.lifes <= 1)
        {
            myImage.sprite = oneLive; 
        }

        else if (player.lifes <= 2)
        {
            myImage.sprite = twoLives;
        }

    }
}
