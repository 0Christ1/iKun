using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GoToFirstLevel(){
        SceneManager.LoadScene("Level 1");
    }

    public void BeginGame(){
        SceneManager.LoadScene("StartScreen");
    }
}

