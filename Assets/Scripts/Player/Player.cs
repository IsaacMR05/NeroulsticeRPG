using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Level level;

    // Start is called before the first frame update
    void Start()
    {
        level = new Level(1, leveledUp);
    }

    private void leveledUp()
    {
        print("Let's goo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
