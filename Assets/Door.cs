using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public int requiredId;
    public Player player;
    private Collider2D collider;
    private SpriteRenderer rend;
    public Sprite openedDoor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.currentID > requiredId)
        {
            rend.sprite = openedDoor;
            collider.enabled = false;
        }
    }
}
