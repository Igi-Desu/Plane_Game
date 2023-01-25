using System.Collections;
using UnityEngine;
using TMPro;
/// <summary>
/// counts down to zero, where game ends
/// </summary>
public class GameEndTimer : Singleton<GameEndTimer>
{
    TextMeshProUGUI timeText;
    int baseTimer=60;
    Coroutine timerCor;

    void Start(){
        timeText=GetComponent<TextMeshProUGUI>();
        GameManager.Instance.AddOnLoseAction(StopTimer);
        GameManager.Instance.AddOnStartAction(StartTimer);
    }
    void StartTimer(){
        //make sure that UI is active before starting coroutine
        transform.root.gameObject.SetActive(true);
        timeText.text=baseTimer.ToString();
        timerCor=StartCoroutine(Timer());
    }
    void StopTimer(){
        if(timerCor==null)return;
        StopCoroutine(timerCor);
        timeText.text=baseTimer.ToString();
        timerCor=null;
    }
    /// <summary>
    /// Ticks down every second and and changes timer text, game ends after it reaches 0.
    /// </summary>
    /// <returns></returns>
    IEnumerator Timer(){
        int timer=baseTimer;
        //timer can be zero and it's by design i like the adrenaline when timer in games shows zero, but
        //there's still one second left
        while(timer>=0){
            yield return new WaitForSeconds(1);
            timer--;
            timeText.text=timer.ToString();
        }
        timerCor=null;
        GameManager.Instance.Lose();
    }
}
