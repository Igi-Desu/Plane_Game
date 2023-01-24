using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    UnityEvent onLose = new UnityEvent();
    UnityEvent OnStart = new UnityEvent();
    GameObject GameUI;
    GameObject StartUI;
    void Start(){
        GameUI=GameObject.Find("GameUI");
        StartUI=GameObject.Find("StartUI");
        GameUI.SetActive(false);
    }
    public void StartGame(){
        OnStart.Invoke();
        StartUI.SetActive(false);
        GameUI.SetActive(true);
        Player.Instance.gameObject.SetActive(true);
    }

    /// <summary>
    /// Set of actions that should happen when we lose game
    /// </summary>
    public void Lose(){
        onLose.Invoke();
        GameUI.SetActive(false);
        StartUI.SetActive(true);
        // Time.timeScale=0;

    }
    /// <summary>
    /// Adds action that shall happen on losing game
    /// </summary>
    /// <param name="callback">action</param>
    /// <returns>added action</returns>
    public UnityAction AddOnLoseAction(UnityAction callback){
        onLose.AddListener(callback);
        return callback;
    }
    public UnityAction RemoveOnLoseAction(UnityAction callback){
        onLose.RemoveListener(callback);
        return callback;
    }
    public UnityAction AddOnStartAction(UnityAction callback){
        OnStart.AddListener(callback);
        return callback;
    }
    public UnityAction RemoveOnStartAction(UnityAction callback){
        OnStart.RemoveListener(callback);
        return callback;
    }
}
