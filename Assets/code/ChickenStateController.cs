using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStateController : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool walk = animator.GetBool("Run");
        bool forwardPressed = Input.GetKey("w");

        if(walk && !forwardPressed)
        {
            animator.SetBool("Run", false);
        }
        if(!walk && forwardPressed)
        {
            animator.SetBool("Run", true);
        }
    }
}
