using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnAnyKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameManager.Instance.AddOnLoseAction(EnableScriptAfterSecond);       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            GameManager.Instance.StartGame();
            this.enabled=false;
        }   
    }
    void EnableScriptAfterSecond(){
        Invoke("EnableScript",1);
    }
    void EnableScript(){
        this.enabled=true;
    }
}
