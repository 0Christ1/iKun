using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scoreBall : MonoBehaviour
{
    public GameObject explosion;
    int score = 0;
    public TextMeshProUGUI scoreUI;
    AudioSource _audioSource;
    public AudioClip clip;

    private void Start()
    {       
        scoreUI.text = "Goals Made:" + score;
        _audioSource = GetComponent<AudioSource>();
    }

    public void newScore(int points){
        score += points;
        scoreUI.text = "Goals Made:" + score;
    }

    

    void Update()
    {
        if (score == 4){
            publicvar.madeGoals = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("goal"))
        {   
            // game_manager.AddScore(point_value);
            
            Instantiate(explosion,transform.position,Quaternion.identity);
            newScore(1);
            _audioSource.PlayOneShot(clip);
            Destroy(other.gameObject);
            
        }
    }
}