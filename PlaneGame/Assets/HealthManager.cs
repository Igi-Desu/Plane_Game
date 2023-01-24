using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : Singleton<HealthManager>
{
    List<GameObject> hearts = new();
    [SerializeField]Sprite heartSprite;
    void Start()
    {
        for(int i=0; i<transform.childCount; i++){
            hearts.Add(transform.GetChild(i).gameObject);
        }
    }

    public void RemoveHeart(){
        hearts[Player.Instance.Hp].SetActive(false);
    }
    private void Restart() {
        foreach(var heart in hearts){
            heart.SetActive(true);
        }
    }
}
