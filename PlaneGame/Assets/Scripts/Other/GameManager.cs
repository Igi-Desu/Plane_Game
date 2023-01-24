using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Everything that should happen when player loses game
    /// </summary>
    UnityEvent onLose = new UnityEvent();
    /// <summary>
    /// Everything that should happen when player starts game
    /// </summary>
    UnityEvent OnStart = new UnityEvent();

    GameObject GameUI;

    GameObject StartUI;

    new protected void Awake(){
        base.Awake();
        GameUI=GameObject.Find("GameUI");
        StartUI=GameObject.Find("StartUI");
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
    //done that way, so that other scripts don't have much control over those events
    public UnityAction AddOnLoseAction(UnityAction callback){
        onLose.AddListener(callback);
        return callback;
    }
    public void RemoveOnLoseAction(UnityAction callback){
        onLose.RemoveListener(callback);
    }
    public UnityAction AddOnStartAction(UnityAction callback){
        OnStart.AddListener(callback);
        return callback;
    }
    public void RemoveOnStartAction(UnityAction callback){
        OnStart.RemoveListener(callback);
    }
}
