using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

using UnityEngine.SceneManagement;

public class shit : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _audioSource.Play();
            publicvar.life-=5;
   
            // _audioSource.Play();
            print("HP-1");
            // new WaitForSeconds(5f);
            // Destroy(gameObject);
        }
    }
}
