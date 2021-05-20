using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform player;

    void LateUpdate()
    {
        Vector3 newPosition;
        newPosition.x = player.position.x;
        newPosition.y = player.position.y;
        newPosition.z = transform.position.z;

        transform.position = newPosition;
    }
}
