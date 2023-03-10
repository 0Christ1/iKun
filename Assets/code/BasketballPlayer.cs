using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

using UnityEngine.SceneManagement;
public class BasketballPlayer : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform spawnPoint;
    GameObject player;
    public GameObject basketballPrefab;
    int basketballSpeed = 400;
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    public string levelToLoad;
    // public GameObject explosion;

    Rigidbody _rigidbody;
    AudioSource _audioSource;
    AudioClip ganma;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        mainCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    
    {
        if(Input.GetMouseButtonDown(0)) //left click  1 = right click 2= middle
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out hit,200))
            {
                //print(hit.collider.gameObject.name);
                print(hit.point);
                _navMeshAgent.destination = hit.point;
            }
        }
        if(publicvar.life<=0)
        {
            SceneManager.LoadScene(levelToLoad);
        }

        if (Input.GetButtonDown("Jump")){
            Vector3 spawn = player.transform.position + new Vector3(1,0,0);
            GameObject shotBasketball = Instantiate(basketballPrefab, spawn, Quaternion.identity);
            shotBasketball.GetComponent<Rigidbody>().AddForce(new Vector3(basketballSpeed,0,0));  
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("key"))
        {
            print(other.name.Substring(3));
            int keynum = Int32.Parse(other.name.Substring(3));  //the format have to like key0 key1 key2 key3.
            Destroy(other.gameObject);
            publicvar.haskey[keynum]=true;
        }
        else if(other.CompareTag("bullet"))
        {
            publicvar.life-=1;
            // _audioSource.Play();
            print("HP-1");
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("enemy"))
        {
            _audioSource.Play();
        }
    }
}
