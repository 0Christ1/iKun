using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canvas : MonoBehaviour
{
    GameManager manager;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + manager.score + "\nlife: "+ publicvar.life;

    }

}
