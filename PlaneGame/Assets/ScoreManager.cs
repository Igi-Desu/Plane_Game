using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : Singleton<ScoreManager>
{
    int currentScore=0;

    TextMeshProUGUI currentScoreText;
    TextMeshProUGUI highScoreText;
    TextMeshProUGUI previousScoreText;
    private void Start() {
        currentScoreText= GameObject.Find("GameUI").transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        highScoreText= GameObject.Find("StartUI").transform.Find("Highscore").GetComponent<TextMeshProUGUI>();
        previousScoreText= GameObject.Find("StartUI").transform.Find("PreviousScore").GetComponent<TextMeshProUGUI>();
        highScoreText.text = PlayerPrefs.GetInt("Highscore",0).ToString();
        previousScoreText.text="0";
        GameManager.Instance.AddOnLoseAction(OnLose);
    }   

    public void IncreaseScore(int amount=1){
        currentScore+=amount;
        currentScoreText.text=currentScore.ToString();
    }
    private void ResetScore(){
        currentScoreText.text="0";
        currentScore=0;
    }

    private void OnLose(){
        UpdateHighScore();
        previousScoreText.text=currentScore.ToString();
        ResetScore();
    }
    public void UpdateHighScore(){
        int currHighScore= PlayerPrefs.GetInt("Highscore",0);
        if(currHighScore<currentScore){
            PlayerPrefs.SetInt("Highscore",currentScore);
            highScoreText.text=currentScore.ToString();
        }
    }
    

}
