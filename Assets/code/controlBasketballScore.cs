using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlBasketballScore : MonoBehaviour
{

    public TextMeshProUGUI scoreUI;
    // Start is called before the first frame update

    public void newScore(){
        publicvar.basketLevelScore += 1;
        scoreUI.text = "Goals Made:" + publicvar.basketLevelScore;
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("bullet")){
           newScore();
        }
        if(publicvar.basketLevelScore == 4){
            publicvar.madeGoals = true;
        }
    }
        

        
   
}
