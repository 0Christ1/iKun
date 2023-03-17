using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    // Start is called before the first frame update
    public bool locked = true;
    int keynum = 0;
    public string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            if(!locked)
            {
                SceneManager.LoadSceneAsync(levelToLoad);
            }
            else if(publicvar.haskey[0] && publicvar.haskey[1] )
            {
                publicvar.haskey[0]=false;
                publicvar.haskey[1]=false;
                SceneManager.LoadSceneAsync(levelToLoad);
            }
            else if (publicvar.madeGoals == true){
                locked = false;
                SceneManager.LoadSceneAsync(levelToLoad);
                locked = true;
                publicvar.madeGoals = false;
            }
            
        }
    }


}
