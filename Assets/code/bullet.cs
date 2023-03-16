using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {   
            // game_manager.AddScore(point_value);
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.CompareTag("enemy"))
        {   
            // game_manager.AddScore(point_value);
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
