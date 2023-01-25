using UnityEngine;
/// <summary>
/// Simple script that starts the game when player presses any button
/// </summary>
public class StartOnAnyKey : MonoBehaviour
{
    void Start()
    {
       GameManager.Instance.AddOnLoseAction(EnableScriptAfterSecond);       
    }

    void Update()
    {
        if(Input.anyKey){
            GameManager.Instance.StartGame();
            this.enabled=false;
        }   
    }
    void EnableScriptAfterSecond(){
        //everyone hates when player doesn't have time to react to screen changing
        //and then starts the game by accident >.>, 1 second should be enough
        Invoke("EnableScript",1);
    }
    void EnableScript(){
        this.enabled=true;
    }
}
