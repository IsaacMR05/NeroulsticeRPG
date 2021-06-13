using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BiomassText : MonoBehaviour
{

    public Player player;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Biomass points available: " + player.level.biomass;
    }
}
