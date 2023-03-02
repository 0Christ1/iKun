using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bot : MonoBehaviour
{
    int bulletSpeed = 250;

    // public Transform spawnPoint;

    public GameObject EnemyBullet;

    NavMeshAgent _navMeshAgent;

    GameObject player;

    Rigidbody _rigidbody;

    Transform playerTransform;

    Transform enemyTransform;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChasePlayer());
        enemyTransform = GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    IEnumerator ChasePlayer()
    {
        while (true)
        {
            _navMeshAgent.destination = player.transform.position;
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            Vector3 force = direction * bulletSpeed;

            Instantiate(EnemyBullet, enemyTransform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            yield return new WaitForSeconds(1);  //0.1s
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