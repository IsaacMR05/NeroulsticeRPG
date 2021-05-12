using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private Health_Manager boxHealth;
    public GameObject box;
    private SpriteRenderer rend;
    private Sprite boxSprite, damagedBoxSprite, tooDamagedBoxSprite;

    // Start is called before the first frame update
    void Start()
    {
        boxHealth = GetComponent<Health_Manager>();
        rend = GetComponent<SpriteRenderer>();
        boxSprite = Resources.Load<Sprite>("Boxes_3");
        damagedBoxSprite = Resources.Load<Sprite>("Boxes_4");
        tooDamagedBoxSprite = Resources.Load<Sprite>("Boxes_5");
    }

    // Update is called once per frame
    void Update()
    {

        if(boxHealth.currentHealth <= 5)
        {
            rend.sprite = tooDamagedBoxSprite;
        }
        else if(boxHealth.currentHealth <= 10)
        {
            rend.sprite = damagedBoxSprite;
        }
        else
        {
            rend.sprite = boxSprite;
        }

    }
}
