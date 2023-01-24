using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : Singleton<ScoreManager>
{
    int currentScore=0;
    
    TextMeshProUGUI scoreText;

    private void Start() {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseScore(int amount=1){
        currentScore+=amount;
        scoreText.text=currentScore.ToString();
    }
}
