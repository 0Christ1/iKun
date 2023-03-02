using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using TMPro;

public class MovePlayer: MonoBehaviour
{

    int score = 0;
    public TextMeshProUGUI scoreUI;
    public AudioClip collectSound;
    AudioSource _audioSource;
    NavMeshAgent _navMeshChar;
    Camera levelCamera;

    Rigidbody _rigidbody;
    
    void Start()
    {
        scoreUI.text = "score: " + score;
        _navMeshChar = GetComponent<NavMeshAgent>();
        levelCamera = Camera.main;
        _audioSource = GetComponent<AudioSource>();
         
    }

    public void AddScore(int points){
        score += points;
        scoreUI.text = "score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(levelCamera.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                _navMeshChar.destination = hit.point;
            }
        }

        if (transform.position.y < 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Key")){
            _audioSource.PlayOneShot(collectSound);
            AddScore(1);
            Destroy(other.gameObject);
            
        }
        if(other.CompareTag("Key1")){
            _audioSource.PlayOneShot(collectSound);
            AddScore(1);
            Destroy(other.gameObject);
            
        }
        if(other.CompareTag("Key2")){
            _audioSource.PlayOneShot(collectSound);
            AddScore(1);
            Destroy(other.gameObject);
            
            PublicVarsGA.hasAllKey = true;
        }
    }
}

