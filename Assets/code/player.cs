using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class player : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("key0"))
        {
            Destroy(other.gameObject);
            publicvar.haskey=true;
        }
    }
}