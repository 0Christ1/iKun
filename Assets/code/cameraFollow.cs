using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Make camera always asyc with the player
    GameObject player;
    Vector3 offset;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        //camera rotate on z axis and keep moving with player
        Vector3 newPos = transform.position;
        newPos.z = player.transform.position.z + offset.z;
        newPos.y = player.transform.position.y + offset.y;
        transform.position = newPos;
        transform.LookAt(player.transform);
    }
}
