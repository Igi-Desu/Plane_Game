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

    public void RemoveHeart(){
        hearts[Player.Instance.Hp].SetActive(false);
    }
    public void Restart() {
        foreach(var heart in hearts){
            heart.SetActive(true);
        }
    }
}
