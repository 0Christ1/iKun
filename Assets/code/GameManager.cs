using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    //private int life = 3;
    public TextMeshProUGUI scoreUI;

    private void Awake()
    {
        //kill all object if go to other sence
        if(GameObject.FindObjectsOfType<GameManager>().Length >1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    public void AddScore(int points)
    {
        score += points;
    }
    
    public void Update()
    {
        
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}
