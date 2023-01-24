using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : Singleton<HealthManager>
{
    List<GameObject> hearts = new();
    [SerializeField]Sprite heartSprite;
    new protected void Awake()
    {
        base.Awake();
        for(int i=0; i<transform.childCount; i++){
            hearts.Add(transform.GetChild(i).gameObject);
        }
    }

    public void RemoveHeart(){
        Debug.Log("Player",Player.Instance.gameObject);
        hearts[Player.Instance.Hp].SetActive(false);
    }
    public void Restart() {
        foreach(var heart in hearts){
            heart.SetActive(true);
        }
    }
}
