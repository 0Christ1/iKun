using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

using UnityEngine.SceneManagement;
public class ChickenAsPlayer : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    public string levelToLoad;
    // public GameObject explosion;
    Animator animator;

    AudioSource _audioSource;
    AudioClip ganma;
    
    private int mouseClickCount = 0;
    //player can shoot basketball
    public GameObject basketballPrefab;
    private int basketballSpeed = 400;
    public Transform spawnPoint;
    GameObject player;
    Rigidbody _rigidbody;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        mainCam = Camera.main;
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //let the chicken player jump at the very start
        if(mouseClickCount==0)
        {
            animator.SetBool("Jump", true);
        }

        if(Input.GetMouseButtonDown(0)) //left click  1 = right click 2= middle
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out hit,200))
            {
                //print(hit.collider.gameObject.name);
                //print(hit.point);
                ++ mouseClickCount;
                _navMeshAgent.destination = hit.point;
                //
                // print(transform.position);
                // print(_navMeshAgent.destination);
                // print(hit.point);
                //
            }
        }
        //chicken state controller: Have the chicken run to the clicking destination and eat when it is reached.
        if(Vector3.Distance(transform.position, _navMeshAgent.destination) <= 0.05)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Eat", true);
            
        }else
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Run", true);
        }

        if(publicvar.life<=0)
        {
            publicvar.life = 1;
            SceneManager.LoadScene("Fail");
        }

        if (Input.GetButtonDown("Jump")){
            // Vector3 spawn = player.transform.position;
            // GameObject shotBasketball = Instantiate(basketballPrefab, spawn, Quaternion.LookRotation(player.transform.forward));
            // shotBasketball.GetComponent<Rigidbody>().AddForce(player.transform.forward * basketballSpeed);  
            
            GameObject shotBasketball = Instantiate(basketballPrefab, spawnPoint.position, Quaternion.LookRotation(spawnPoint.transform.forward));
            shotBasketball.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * basketballSpeed); 
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



