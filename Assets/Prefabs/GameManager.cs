using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private int life = 3;
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
    private void Start()
    {
        // scoreUI.text = " LIFE: " + publicvar.life;
    }
    // public void AddScore(int points)
    // {
    //     score += points;
    //     scoreUI.text = " LIFE: " + publicvar.life;

    // }
    // public void KillLife()
    // {
    //     life -= 1;
    //     scoreUI.text = "SCORE: " + score +" LIFE: " + life;

    // }
    // Update is called once per frame
    public void Update()
    {
        scoreUI.text = " LIFE: " + publicvar.life;
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}
