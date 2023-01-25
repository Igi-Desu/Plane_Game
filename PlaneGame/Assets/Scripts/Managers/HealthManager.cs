using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    List<GameObject> hearts = new();
    [SerializeField]Sprite heartSprite;
    new protected void Awake()
    {
        //add all heart objects to list
        base.Awake();
        for(int i=0; i<transform.childCount; i++){
            hearts.Add(transform.GetChild(i).gameObject);
        }
    }
    /// <summary>
    /// removes one heart from HUD
    /// </summary>
    /// <param name="which">number of heart starting from 0</param>
    public void RemoveHeart(int which){
        if(which<0||which>3)return;
        hearts[which].SetActive(false);
    }
    public void Restart() {
        foreach(var heart in hearts){
            heart.SetActive(true);
        }
    }
}
