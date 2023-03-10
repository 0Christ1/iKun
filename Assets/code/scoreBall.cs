using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBall : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("goal"))
        {   
            // game_manager.AddScore(point_value);
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("bullet"))
        {   
            // game_manager.AddScore(point_value);
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}