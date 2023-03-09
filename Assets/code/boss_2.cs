using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss_2 : MonoBehaviour
{
    int bulletSpeed = 10;

    public Transform spawnPoint;

    public GameObject EnemyBullet;

    public GameObject Trap;



    NavMeshAgent _navMeshAgent;

    GameObject player;

    Rigidbody _rigidbody;

    AudioSource _audioSource;

    void Start()
    {
        // _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (true)
        {
            _navMeshAgent.destination = player.transform.position;

            Vector3 direction = (player.transform.position - spawnPoint.position).normalized;

            Vector3 force = direction * bulletSpeed;
            
            // Instantiate(EnemyBullet, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            Instantiate(Trap, spawnPoint.position, Quaternion.identity);
            _audioSource.Play();

            yield return new WaitForSeconds(7f);  //0.1s
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            publicvar.life-=1;
            print("HP-1");
        }
    }
}