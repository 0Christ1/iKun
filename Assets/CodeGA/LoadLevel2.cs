using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    public string nextLevel;
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            if (PublicVarsGA.hasAllKey){
                PublicVarsGA.hasAllKey = false;
                SceneManager.LoadScene(nextLevel);
            }
            
        }
    }
}
