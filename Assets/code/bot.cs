using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bot : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);  //0.1s
            _navMeshAgent.destination = player.transform.position;
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