using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scoreBall : MonoBehaviour
{

    GameObject basketball;
    public GameObject explosion;
    int score = 0;
    public TextMeshProUGUI scoreUI;
    AudioSource _audioSource;
    public AudioClip clip;

    private void Start()
    {     
        basketball = GameObject.FindGameObjectWithTag("bullet");  
        _audioSource = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("goal"))
        {   
            // game_manager.AddScore(point_value);
            Instantiate(explosion,transform.position,Quaternion.identity);
            _audioSource.PlayOneShot(clip);
            Destroy(other.gameObject);
            
        }
        // if(other.CompareTag("enemy"))
        // {
        //     Instantiate(explosion,transform.position,Quaternion.identity);
        //     _audioSource.PlayOneShot(clip);
        //     Destroy(other.gameObject);
        // }
    }
}