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
                SceneManager.LoadScene(levelToLoad);
            }
            else if(publicvar.haskey[0] &&publicvar.haskey[1] )
            {
                publicvar.haskey[keynum]=false;
                SceneManager.LoadScene(levelToLoad);
            }
            
        }
    }


}
