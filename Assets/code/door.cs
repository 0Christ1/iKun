using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(publicvar.haskey)
            {
                publicvar.haskey=false;
                SceneManager.LoadScene(levelToLoad);
            }
            
        }
    }


}
