using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    UnityEvent onLose;

    /// <summary>
    /// Set of actions that should happen when we lose game
    /// </summary>
    public void Lose(){
        onLose.Invoke();
        Time.timeScale=0;

    }
    /// <summary>
    /// Adds action that shall happen on losing game
    /// </summary>
    /// <param name="Callback">action</param>
    /// <returns>added action</returns>
    public UnityAction AddOnLoseAction(UnityAction Callback){
        onLose.AddListener(Callback);
        return Callback;
    }
    public UnityAction RemoveOnLoseAction(UnityAction Callback){
        onLose.RemoveListener(Callback);
        return Callback;
    }
}
